
    app.controller('ctrPhieuThuVayNo', ctrPhieuThuVayNo)
    app.controller('InstanceController', InstanceController)
    app.directive("datepicker", function () {
        return {
            restrict: "A",
            scope: false,
            require: "ngModel",
            link: function (scope, elem, attrs, ngModelCtrl) {
                var updateModel = function (date) {
                    scope.$apply(function () {
                        ngModelCtrl.$setViewValue(date);
                    });
                };
                var options = {
                    onSelect: function (dateText) {
                        updateModel(dateText);
                    }
                };
                elem.datetimepicker({ format: 'DD/MM/YYYY' }).on('dp.change', function (data) {
                    updateModel(data.date);
                });
            }
        }
    });


    ctrPhieuThuVayNo.$inject = ['$scope', "$location", '$http', '$uibModal'];

    function ctrPhieuThuVayNo($scope, $location, $http, $uibModal) {

        //array tổng hợp
        $scope.arrayTongHop = {
            ma_doi_tuong: '',
            ma_cong_ty: '',
            ten_doi_tuong: '',
            dia_chi:'',
            so_tk_nop: '',
            ten_ngan_hang: '',
            ly_do_thu: '',
            dien_giai_ly_do_thu: '',
            nhan_vien_thu: '',
            HO_VA_TEN: '',
            ma_phong_ban:'',
            nguoi_lap_bieu: '',
            ho_va_ten_lap_bieu: '',
            ho_va_ten: '',
            ngay_hach_toan: '',
            ngay_chung_tu: '',
            tong_tien:0
        };
        

        $scope.arraydiengiai = [{
            loai_tien: '',
            ty_gia: '',
            tk_no: '',
            tk_co: '',
            so_tien: '',
            quy_doi: '',
            diengiai: ''
        }];

        $scope.arrayCTTC = [];

        $scope.indexcurrent = 0;

        //method change type reason.
        $scope.reasonmoney = 'VayNo';

        //mảng đối tượng
        $scope.arrayDTFinded = [];
        $scope.arrayDT = [];
        $scope.showtable_ma_doi_tuong = false;
        $scope.hovertable = false;
        $scope.hoverbtn_MDT = false;

        //save value TK ngân hàng
        $scope.arrayBanks = [];

        //mang nhân viên
        $scope.arrayNVFinded = [];
        $scope.arrayStaffs = [];
        $scope.staffThu = '';
        $scope.showtable_ho_va_ten = false;

        //phần tham chiếu chứng từ:
        $scope.usingchoise_CTTC = true;
        $scope.chung_tu_selected = '';

        //nguoi lạp bieu
        $scope.staffLapBieu = '';

        //array tk hack toan
        $scope.arrayBankHackToan = [];
        $scope.bankTKNo = {};
        $scope.bankTKCo = {};




        /*
        * get Đối Tượng
        */
        $http.get(window.location.origin + '/api/Api_DM_DOI_TUONG')
         .then(function (response) {
             if (response.data) {
                 $scope.arrayDT = response.data;
                 $scope.arrayDTFinded = $scope.arrayDT.map(function (item) {
                     return item;
                 });
             }
         }, function (error) {
             console.log(error);
         });

        /**
        * get tk ngân hàng
        */
        $http.get(window.location.origin + '/api/Api_DM_TK_NGAN_HANG_NOI_BO')
            .then(function (response) {
                if (response.data) {
                    $scope.arrayBanks = response.data;
                }
            }, function (error) {
                console.log(error);
            });

        /**
        * get nhan viên
        */
        $http.get(window.location.origin + '/api/NGUOI_DUNG_FULL')
            .then(function (response) {
                if (response.data) {
                    $scope.arrayStaffs = response.data;
                    $scope.arrayNVFinded = $scope.arrayStaffs.map(function (item) {
                        return item;
                    });
                }
            }, function (error) {
                console.log(error);
            });

        /**
        * get tài khoản hạch toán
        */
        $http.get(window.location.origin + '/api/Api_TaiKhoanHachToan')
            .then(function (response) {
                if (response.data) {
                    $scope.arrayBankHackToan = response.data;
                }
            }, function (error) {
                console.log(error);
            });

        /**
       *loc dữ liệu khi input thay đổi
       */
        $scope.onDoiTuongFind = function () {
            if (!$scope.TEN_DOI_TUONG) {
                $scope.arrayDTFinded = $scope.arrayDT.map(function (item) {
                    return item;
                });
            }
            $scope.arrayDTFinded = $scope.arrayDT.filter(function (item) {
                if (item.TEN_DOI_TUONG.toLowerCase().indexOf($scope.arrayTongHop.ma_doi_tuong.toLowerCase()) >= 0) {
                    return true;
                } else {
                    return false;
                }
            });
        }
        $scope.onBlurInput_MDT = function () {
            if ($scope.hoverbtn_MDT || $scope.hovertable_MDT) {
                return;
            }
            $scope.showtable_ma_doi_tuong = false;
        }
        /**
       *loc dữ liệu khi input nhân viên thay đổi
       */
        $scope.onNhanVienFind = function () {
            if (!$scope.HO_VA_TEN) {
                $scope.arrayNVFinded = $scope.arrayStaffs.map(function (item) {
                    return item;
                });
            }
            $scope.arrayNVFinded = $scope.arrayStaffs.filter(function (item) {
                if (item.HO_VA_TEN.toLowerCase().indexOf($scope.arrayTongHop.ho_va_ten.toLowerCase()) >= 0) {
                    return true;
                } else {
                    return false;
                }
            });
        }
      
        /**
            *Show tên nhân viên
        */
        $scope.showInfoStaff = function (p_staff) {
            $scope.arrayTongHop.nhan_vien_thu = p_staff.USERNAME;
            $scope.arrayTongHop.ho_va_ten = p_staff.HO_VA_TEN;
            $scope.arrayTongHop.ma_phong_ban = p_staff.MA_PHONG_BAN;
            $scope.showtable_ho_va_ten = false;
        }


        /*
        * Method Change Lý Do Thu
        */
        $scope.changeType = function ($event) {
            window.location.href = window.location.origin + '/PhieuThuNganHang/' + $scope.reasonmoney;
        };

        /*
        * method show info Đối Tượng Khi user lựa chọn.
        */
        $scope.showInfoDT = function (p_dt) {
            $scope.arrayTongHop.ma_doi_tuong = p_dt.MA_DOI_TUONG;
            $scope.arrayTongHop.ma_cong_ty = p_dt.MA_CONG_TY;
            $scope.arrayTongHop.ten_doi_tuong = p_dt.TEN_DOI_TUONG;
            $scope.arrayTongHop.dia_chi = p_dt.DIA_CHI;
            $scope.hovertable = false;
            $scope.showtable_ma_doi_tuong = false;
        }

        /**
        * method show thông tin tk
        */
        $scope.showInfoTK = function (p_bank) {
            $scope.arrayTongHop.so_tk_nop = p_bank.SO_TAI_KHOAN;
            $scope.arrayTongHop.ten_ngan_hang = p_bank.TEN_NGAN_HANG;
        }

        /**
        * saff nhập biểu
        */
        $scope.setStaffLapBieu = function (p_staff) {
            $scope.arrayTongHop.nguoi_lap_bieu = p_staff.USERNAME;
            $scope.arrayTongHop.ho_va_ten_lap_bieu = p_staff.HO_VA_TEN;
        }

        /**
        *chọn tk nợ
        */
        $scope.showInfoTKNo = function (p_tkno) {
            $scope.arraydiengiai[$scope.indexcurrent].tk_no = p_tkno.SO_TK;
        }

        /**
        * chọn tk có
        */
        $scope.showInfoTKCo = function (p_tkco) {
            $scope.arraydiengiai[$scope.indexcurrent].tk_co = p_tkco.SO_TK;
        }

        /**
       * Thêm mới code
       */
        $scope.addTongHop = function () {
            $scope.arraydiengiai.push({
                loai_tien: '',
                ty_gia: '',
                tk_no: '',
                tk_co: '',
                so_tien: '',
                quy_doi: ''
            });
            $scope.indexcurrent = $scope.arraydiengiai.length - 1;
        }

        $scope.onChangeIndex = function (p_index) {
            $scope.indexcurrent = p_index;
        }


        /**
        * Chứng từ tham chiếu
        */
        $scope.animationsEnabled = true;
        //based on size parameter the size of modal chages.
        $scope.openModal = function () {
            $scope.modalPopup().then(function (data) {
                      $scope.handleSuccess(data);
                  })
                  .then(null, function (reason) {
                      $scope.handleDismiss(reason);
                  });
        };

        $scope.modalPopup = function () {
            var ModalInstance = $uibModal.open({
                animation: $scope.animationsEnabled,
                templateUrl: 'myModal.html',
                controller: 'InstanceController',
                //appendTo:     //appends the modal to a element
                backdrop: false,  //disables modal closing by click on the background
                //size:size,
                //template: 'myModal.html',
                //keyboard:true,     //dialog box is closed by hitting ESC key
                //openedClass:'nameofClass',  //class styles are applyed after dialog opens.
                resolve: {
                    items: function () {
                        //we can send data from here to controller using resolve...
                        return $scope.arrayCTTC;
                    }
                }
                //windowClass:'AddtionalClass',   //class that is added to styles the window template
                //windowTemplateUrl:'Modaltemplate.html',    template overrides the modal template
            });
            return ModalInstance.result;
        };

        $scope.handleSuccess = function (data) {
            $scope.usingchoise_CTTC = true;
            $scope.arrayCTTC = data;
        }

        $scope.handleDismiss = function (reason) {
            $scope.usingchoise_CTTC = false;
            console.log('Modal dismissed: ' + reason);
        }

        
            
        

        $scope.onSave = function () {
                if (!$scope.arrayTongHop.ma_doi_tuong) {
                    alert('Thiếu thông tin Mã Đối Tượng');
                    return;
                }

                if (!$scope.arrayTongHop.so_tk_nop) {
                    alert('Thiếu thông tin Tài Khoản Nộp');
                    return;
                }

                if (!$scope.arrayTongHop.nhan_vien_thu) {
                    alert('Thiếu thông tin Nhân Viên Thu');
                    return;
                }

                
                
                //if (!$scope.arrayTongHop[i].so_ct_tham_chieu) {
                //    alert('Thiếu thông tin Số Chứng Từ Tham Chiếu của hàng ' + (i + 1));
                //    return;
                //}
                if (!$scope.arrayTongHop.ngay_hach_toan) {
                    alert('Thiếu thông tin Ngày Hạch Toán');
                    return;
                }

                if (!$scope.arrayTongHop.ngay_chung_tu) {
                    alert('Thiếu thông tin Ngày Chứng Từ');
                    return;
                }
                if ($scope.arrayTongHop.ngay_hach_toan < $scope.arrayTongHop.ngay_chung_tu) {
                    alert('Ngày Hạch Toán phải lớn hơn hoặc bằng Ngày Chứng Từ');
                    return;
                }

                var tongtien = 0;
                for (var i = 0; i < $scope.arraydiengiai.length; i++) {
                    if (!$scope.arraydiengiai[i].loai_tien) {
                        alert('Thiếu thông tin Loại Tiền - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!$scope.arraydiengiai[i].tk_no) {
                        alert('Thiếu thông tin Tài Khoản Nợ - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!$scope.arraydiengiai[i].tk_co) {
                        alert('Thiếu thông tin Tài Khoản Có - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!$scope.arraydiengiai[i].so_tien) {
                        alert('Thiếu thông tin Số Tiền - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if ($scope.arraydiengiai[i].loai_tien == 'VND') {
                        $scope.arraydiengiai[i].ty_gia = 1;
                    }

                    if (!$scope.arraydiengiai[i].ty_gia) {
                        alert('Thiếu thông tin Tỷ Giá - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!$scope.arraydiengiai[i].diengiai) {
                        alert('Thiếu thông tin Diễn Giải - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }
                    $scope.arraydiengiai[i].quy_doi = $scope.arraydiengiai[i].so_tien * $scope.arraydiengiai[i].ty_gia;
                    tongtien += $scope.arraydiengiai[i].quy_doi;
                }
                $scope.arrayTongHop.tong_tien = tongtien;
                
                var a = $('#sdfsdfsd').val();
                $scope.NH_NTTK = {
                    NGAY_HACH_TOAN: $scope.arrayTongHop.ngay_hach_toan.format('YYYY-MM-DD'),
                    NGAY_CHUNG_TU: $scope.arrayTongHop.ngay_chung_tu.format('YYYY-MM-DD'),
                    MA_DOI_TUONG: $scope.arrayTongHop.ma_doi_tuong,
                    NOP_VAO_TAI_KHOAN: $scope.arrayTongHop.so_tk_nop,
                    LY_DO_THU: 'Vay nợ',
                    DIEN_GIAI_LY_DO_THU: $scope.arrayTongHop.dien_giai_ly_do_thu,
                    NHAN_VIEN_THU: $scope.arrayTongHop.nhan_vien_thu,
                    TONG_TIEN: $scope.arrayTongHop.tong_tien,
                    NGUOI_LAP_BIEU: a,
                    TRUC_THUOC: $scope.arrayTongHop.ma_cong_ty
                };

                $scope.NH_CT_NTTKs = [];
                for (var i = 0; i < $scope.arraydiengiai.length; i++) {
                    var nH_CT_NTTK = {
                        DIEN_GIAI: $scope.arraydiengiai[i].diengiai,
                        LOAI_TIEN: $scope.arraydiengiai[i].loai_tien,
                        TY_GIA: $scope.arraydiengiai[i].ty_gia,
                        TK_NO: $scope.arraydiengiai[i].tk_no,
                        TK_CO: $scope.arraydiengiai[i].tk_co,
                        SO_TIEN: $scope.arraydiengiai[i].so_tien,
                        QUY_DOI: $scope.arraydiengiai[i].quy_doi,
                        MA_DOI_TUONG: $scope.arrayTongHop.ma_doi_tuong,
                        DON_VI: $scope.arrayTongHop.ma_phong_ban
                    }
                    $scope.NH_CT_NTTKs.push(nH_CT_NTTK);
                }

                $scope.THAM_CHIEU = [];
                for (var i = 0; i < $scope.arrayCTTC.length; i++) {
                    var tHAM_CHIEU = {
                        SO_CHUNG_TU_THAM_CHIEU: $scope.arrayCTTC[i].ma_chung_tu
                    }
                    $scope.THAM_CHIEU.push(tHAM_CHIEU);
                }

                //for (var i = 0; i < $scope.arrayTongHop.length; i++) {
                //    var nH_NTTK = {
                //        NGAY_HACH_TOAN: $scope.arrayTongHop[i].ngay_hach_toan.format('YYYY-MM-DD'),
                //        NGAY_CHUNG_TU: $scope.arrayTongHop[i].ngay_chung_tu.format('YYYY-MM-DD'),
                //        MA_DOI_TUONG: $scope.arrayTongHop[i].ma_doi_tuong,
                //        NOP_VAO_TAI_KHOAN: $scope.arrayTongHop[i].so_tk_nop,
                //        LY_DO_THU: 'Thu khác',
                //        DIEN_GIAI_LY_DO_THU: $scope.arrayTongHop[i].dien_giai_ly_do_thu,
                //        NHAN_VIEN_THU: $scope.arrayTongHop[i].nhan_vien_thu,
                //        TONG_TIEN: $scope.arrayTongHop[i].so_tien,
                //        NGUOI_LAP_BIEU: $scope.arrayTongHop[i].nguoi_lap_bieu,
                //        TRUC_THUOC: $scope.arrayTongHop[i].ma_cong_ty
                //    }  
                //    var nH_CT_NTTK = {
                //        DIEN_GIAI: $scope.arrayTongHop[i].diengiai,
                //        LOAI_TIEN: $scope.arrayTongHop[i].loai_tien,
                //        TY_GIA: $scope.arrayTongHop[i].ty_gia,
                //        TK_NO: $scope.arrayTongHop[i].tk_no,
                //        TK_CO: $scope.arrayTongHop[i].tk_co,
                //        SO_TIEN: $scope.arrayTongHop[i].so_tien,
                //        QUY_DOI: $scope.arrayTongHop[i].quy_doi,
                //        MA_DOI_TUONG: $scope.arrayTongHop[i].ma_doi_tuong,
                //        DON_VI: $scope.arrayTongHop[i].ma_phong_ban
                //    }
                //    if ($scope.arrayTongHop[i].loai_tien == 'VND') {
                //        nH_CT_NTTK.QUY_DOI = nH_CT_NTTK.SO_TIEN;
                //    } else {
                //        nH_CT_NTTK.QUY_DOI = nH_CT_NTTK.TY_GIA * nH_CT_NTTK.SO_TIEN;
                //    }

                //    var tHAM_CHIEU = {
                //        SO_CHUNG_TU_THAM_CHIEU: $scope.arrayTongHop[i].so_ct_tham_chieu
                //    }
                //    $scope.NH_NTTKs.push(nH_NTTK);
                //    $scope.NH_CT_NTTKs.push(nH_CT_NTTK);
                //    $scope.THAM_CHIEU.push(tHAM_CHIEU);
                //}

                $http({
                    method: 'POST',
                    data: $scope.NH_NTTK,
                    url: window.location.origin + '/api/Api_NH_NTTK'
                }).then(function successCallback(response) {
                    $scope.NH_NTTK = response.data;
                    if (!$scope.NH_NTTK) {
                        alert('Tạo Lỗi 1');
                        return;
                    }

                    //for (var i = 0; i < $scope.nH_NTTKs.length; i++) {
                    //    $scope.NH_CT_NTTKs[i].SO_CHUNG_TU = $scope.nH_NTTKs[i].so_chung_tu;
                    //    $scope.THAM_CHIEU[i].SO_CHUNG_TU_GOC = $scope.nH_NTTKs[i].so_chung_tu;
                    //}

                    for (var i = 0; i < $scope.NH_CT_NTTKs.length; i++) {
                        $scope.NH_CT_NTTKs[i].SO_CHUNG_TU = $scope.NH_NTTK.so_chung_tu;
                    }

                    for (var i = 0; i < $scope.THAM_CHIEU.length; i++) {
                        $scope.THAM_CHIEU[i].SO_CHUNG_TU_GOC = $scope.NH_NTTK.so_chung_tu;
                    }
                    
                    if ($scope.NH_CT_NTTKs.length > 0) {
                        $http({
                            method: 'POST',
                            data: $scope.NH_CT_NTTKs,
                            url: window.location.origin + '/api/Api_NH_CT_NTTK/Multi'
                        }).then(function successCallback(response1) {
                            if ($scope.THAM_CHIEU.length > 0) {
                                $http({
                                    method: 'POST',
                                    data: $scope.THAM_CHIEU,
                                    url: window.location.origin + '/api/Api_XL_THAM_CHIEU_CHUNG_TU/Multi'
                                }).then(function successCallback(response) {
                                    alert("Hoàn Thành Lưu");
                                }, function errorCallback(response) {
                                    alert('Tạo Lỗi3');
                                });
                            } else {
                                alert("Hoàn Thành Lưu");
                            }
                        }, function errorCallback(response1) {
                            alert('Tạo Lỗi2');
                        });
                        return;
                    }

                    if ($scope.THAM_CHIEU.length > 0) {
                        $http({
                            method: 'POST',
                            data: $scope.THAM_CHIEU,
                            url: window.location.origin + '/api/Api_XL_THAM_CHIEU_CHUNG_TU/Multi'
                        }).then(function successCallback(response) {
                            alert("Hoàn Thành Lưu");
                        }, function errorCallback(response) {
                            alert('Tạo Lỗi3');
                        });
                    } else {
                        alert("Hoàn Thành Lưu");
                    }
                }, function errorCallback(response) {
                    console.log(response);
                    alert('Tạo Lỗi');
                });
        }

        $scope.onHuy = function () {
            window.location.href = window.location.origin + '/PhieuThuNganHang/' + $scope.reasonmoney;
        }

    
    }

    function InstanceController($scope, $http, $uibModalInstance, items) {
        /**
        * lấy dữ liệu ban đầu
        */
        $scope.loaichungtu = 'LoaiChungTu';
        $scope.showchungtu = true;

        $scope.valueLoaiChungTu = [];

        $scope.valueselected_CTTC = '';
        $scope.valueselected_LoaiChungTu_CTTC = '';

        $scope.dataFinded = [];
        $scope.chung_tu_selected = [];

        console.log(items);

        if (items.length) {
            items.forEach(function (item) {
                $scope.dataFinded.push(item);
                $scope.chung_tu_selected.push(item);
            });
        }

        //phuong thuc get value gia tri
        $scope.getValue_CTTC = function (p_type) {
            let urlget = '';
            switch (p_type) {
                case 'LoaiChungTu':
                    urlget = window.location.origin + '/api/Api_Loaichungtu';
                    break;
                case 'DoiTuong':
                    urlget = window.location.origin + '/api/Api_DM_DOI_TUONG';
                    break;
                default:
                    urlget = window.location.origin + '/api/Api_ChungTu';
                    break
            }

            $http.get(urlget)
              .then(function (response) {
                  if (response.data) {
                      if (p_type != 'DoiTuong') {
                          $scope.valueLoaiChungTu = response.data.map(function (item) {
                              if ($scope.loaichungtu != 'LoaiChungTu') {
                                  item.name = item.MA_CHUNG_TU
                              } else {
                                  item.name = item.MA_LOAI_CHUNG_TU
                              }
                              return item;
                          });
                      } else {
                          $scope.valueLoaiChungTu = response.data;
                      }
                  }
              }, function (error) {
                  console.log(error);
              });
        }

        $scope.getValue_CTTC($scope.loaichungtu);

        $scope.changeTypeThamChieu = function ($event) {
            if ($scope.loaichungtu != 'DoiTuong') {
                $scope.showchungtu = true;
            } else {
                $scope.showchungtu = false;
            }
            $scope.valueselected_CTTC = '';
            $scope.valueselected_LoaiChungTu_CTTC = '';

            $scope.valueLoaiChungTu = [];
            $scope.getValue_CTTC($scope.loaichungtu);
        }

        $scope.ok = function () {
            if ($scope.chung_tu_selected) {
                $uibModalInstance.close($scope.chung_tu_selected);
            } else {
                alert("Bạn Cần Chọn Một Chứng Từ Tham Chiếu!")
            }         
        };
        $scope.cancel = function () {
            //it dismiss the modal 
            $uibModalInstance.dismiss('cancel');
        };

        $scope.optionGameValue = function(){

        }

        /**
        * Method được gọi khi click chọn đối tượng
        */
        $scope.showSlected = function (p_dt) {
            $scope.valueselected_CTTC = p_dt;
        }

        /**
        * getData
        */
        $scope.getData = function () {
            $scope.dataFinded = [];
            $scope.ma_chung_tu = '';
            //$scope.chung_tu_selected = '';
            switch($scope.loaichungtu) {
                case 'LoaiChungTu':
                    $scope.getDataLoaiChungTu();
                    break;
                case 'DoiTuong':
                    $scope.getDataDoTuong();
                    break;
                default:
                    $scope.getDataSoHoaDon();
                    break
            }
        }
        /**
        * get data cho Đối Tượng
        */
        $scope.getDataDoiTuong = function () {
            $http.get(window.location.origin + '/api/Api_ChungTu/')
             .then(function (response) {
                 if (response.data) {
                     $scope.joinArray(response.data);
                 }
             }, function (error) {
                 console.log(error);
             });
        }

        /**
        * get data cho loại Chứng Từ
        */
        $scope.getDataLoaiChungTu = function () {
            $http.get(window.location.origin + '/api/Api_ChungTu/')
              .then(function (response) {
                  if (response.data) {
                      $scope.joinArray(response.data);
                  }
              }, function (error) {
                  console.log(error);
              });
        }

        /**
        * get data cho Số hóa đơn
        */
        $scope.getDataSoHoaDon = function () {
            let arrResult = $scope.valueLoaiChungTu.filter(item => {
                return $scope.valueselected_LoaiChungTu_CTTC.MA_CHUNG_TU == item.MA_CHUNG_TU;
            });
            $scope.joinArray(arrResult);
        }

        $scope.joinArray = function (arrResult) {
            $scope.dataFinded = [];
            $scope.chung_tu_selected.forEach(function (item) {
                $scope.dataFinded.push(item);
            });
            arrResult.forEach(function (item) {
                let t_temp = $scope.dataFinded.find(function (item1) {
                    return (item1.MA_CHUNG_TU == item.MA_CHUNG_TU)
                });
                if (!t_temp) {
                    $scope.dataFinded.push(item);
                }
            });
        }

        /**
        * check lấy dữ liệu
        */
        $scope.changeChecked = function (valuefind) {
            let ishave = false;
            let t_index= $scope.chung_tu_selected.findIndex(function (item) {
                if (item.MA_CHUNG_TU == valuefind.MA_CHUNG_TU) {
                    return true;
                } else {
                    return false;
                }
            });

            if (t_index >= 0) {
                valuefind.selected = false;
                $scope.chung_tu_selected.splice(t_index, 1);
            } else {
                valuefind.selected = true;
                $scope.chung_tu_selected.push(valuefind);
            }
        }
    }


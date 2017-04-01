

app.controller('ctrTamUngNhanVien', ctrTamUngNhanVien);
ctrTamUngNhanVien.$inject = ['$scope', 'DataService', '$uibModal'];
function ctrTamUngNhanVien($scope, DataService, $uibModal) {
    $scope.title = 'ctrTamUngNhanVien';

        $scope.ui = {
            activeTabThue: false,
            hideTabThue: false
        }

        //Danh sách các tài khoản ngân hàng(DM_TK_NGAN_HANG_NOI_BO)
        $scope.listTknh = [];
        // Danh sách các đối tượng (DM_DOI_TUONG)
        $scope.listDoiTuong = [];
        // Danh sách các tài khoản nhận (NCC_TK_NGAN_HANG)
        $scope.listNccTknh = [];
        // Danh sách các nhà cung cấp
        $scope.listNCC = [];
        // Danh sách nhân viên(NCC_TK_NGAN_HANG)
        $scope.listStaff = [];

        $scope.dinh_khoan_tu_dong = null;

        // Danh sách các nội dung thanh toán
        $scope.listNoiDungTT = [
            "Tạm Ứng Nhân Viên"
            
        ];

        function initValue() {
            $scope.$submitted = false;

            $scope.info = {
                noi_dung_thanh_toan: '',
                so_tai_khoan: null,
                ten_ngan_hang: '',
                ma_doi_tuong: null,
                ten_doi_tuong: '',
                ncc_so_tai_khoan: null,
                ncc_ten_ngan_hang: ''
            }

            // Mảng các chứng từ tham chiếu
            $scope.arrayCTTC = [];

            // Danh sách hạch toán
            $scope.listHachToan = [];
            // Mỗi item hạch toán có 1 item thuế
            $scope.listThue = [];
            $scope.itemHachToanSelect = -1;

            $scope.arrayBlank = [{},{},{},{},{},{}];
        };

        initValue();

        // Lấy list tài khoản ngân hàng
        $scope.getTaiKhoanNganHang = function() {
            var data = {};
            $scope.listTknh = [];

            function success(response) {
                $scope.listTknh = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getTaiKhoanNganHang(data, success, error, $('#container'));
        };

        // Chọn tài khoản ngân hàng
        $scope.selectTaiKhoanNganHang = function(tknh) {
            $scope.info.so_tai_khoan = tknh.SO_TAI_KHOAN;
            $scope.info.ten_ngan_hang = tknh.TEN_NGAN_HANG;
        };

        // Lấy list đối tượng
        $scope.getDoiTuong = function() {
            var data = {};
            $scope.listDoiTuong = [];

            function success(response) {
                $scope.listDoiTuong = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getDoiTuong(data, success, error, $('#container'));
        };

        // Chọn đối tượng
        $scope.selectDoiTuong = function(doi_tuong) {
            $scope.info.ma_doi_tuong = doi_tuong.MA_DOI_TUONG;
            $scope.info.ma_cong_ty = doi_tuong.MA_CONG_TY;
            $scope.info.ten_doi_tuong = doi_tuong.TEN_DOI_TUONG;
        };

 
    // Lấy list NCC
        $scope.getNccTaiKhoanNganHang = function() {
            var data = {};
            $scope.listNccTknh = [];

            function success(response) {
                $scope.listNccTknh = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getNccTaiKhoanNganHang(data, success, error, $('#container'));
        };

        $scope.selectNccTaiKhoanNganHang = function(doi_tuong) {
            $scope.info.ncc_so_tai_khoan = doi_tuong.SO_TAI_KHOAN;
            $scope.info.ncc_ten_ngan_hang = doi_tuong.TEN_NGAN_HANG;
        };

        $scope.onChangeNoiDungThanhToan = function() {
            console.log('aaaa');
            var noi_dung_thanh_toan = this.info.noi_dung_thanh_toan;
            var hideTabThue = noi_dung_thanh_toan === "Chi khác" ? false : true;
            $scope.ui = {
                hideTabThue: hideTabThue,
                activeTabThue: false
            };
        };

        $scope.activeTab = function(tab) {
            console.log(tab);
            switch (tab) {
                case "Thuế":
                    $scope.ui.activeTabThue = true;
                    break;
                case "Hạch toán":
                    $scope.ui.activeTabThue = false;
                    break;
            }
        };

        $scope.selectNhanVienThu = function (p_staff) {
            $scope.info.nhan_vien_thu = p_staff;
        };

        $scope.selectNguoiLapBieu = function (p_staff) {
            $scope.info.nguoi_lap_bieu = p_staff;
        };

        $scope.startThamChieuChungTu = function () {
            function modalThamChieuChungTu() {
                var ModalInstance = $uibModal.open({
                    animation: $scope.animationsEnabled,
                    templateUrl: 'ThamChieuChungTu.html',
                    controller: 'ctrThamChieuChungTu',
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
            }

            function handleSuccess(data) {
                console.log('chọn chứng từ:', data);
                $scope.arrayCTTC = data;
            }

            function handleDismiss() {
                console.log('Hủy chọn chứng từ');
            }

            modalThamChieuChungTu().then(function (data) {
                handleSuccess(data);
            }).then(null, function (reason) {
                handleDismiss(reason);
            });
        };

        $scope.addHachToan = function() {
            var dk = $scope.dinh_khoan_tu_dong;

            $scope.listHachToan.push({
                dien_giai: null,
                tk_no: dk ? dk.tk_no : null,
                tk_co: dk ? dk.tk_co : null,
                so_tien: 0,
                quy_doi: 0,
                don_vi: null, // loại tiền
                ty_gia: 0
            });

            $scope.listThue.push({
                dien_giai: null,
                tk_thue: null,
                tien_thue: null,
                phan_tram_thue: null,
                gia_tri_chua_thue: null,
                ngay_hoa_don: null,
                so_hoa_don: null,
                mau_so_hd: null,
                ky_hieu_hd: null,
                ma_ncc: null
            });

            $scope.itemHachToanSelect = $scope.listHachToan.length - 1;
            $scope.arrayBlank.shift();
        };

        $scope.onSelectItemHachToan = function(index) {
            $scope.itemHachToanSelect = index;
        };

        $scope.selectTkNo = function(tk_no) {
            $scope.listHachToan[$scope.itemHachToanSelect].tk_no = tk_no.SO_TK;
        };


        $scope.selectTkCo = function(tk_co) {
            $scope.listHachToan[$scope.itemHachToanSelect].tk_co = tk_co.SO_TK;
        };


        $scope.selectTkThue = function(tk_thue) {
            $scope.listThue[$scope.itemHachToanSelect].tk_thue = tk_thue.SO_TK;
        };

        $scope.selectNcc = function(ncc) {
            $scope.listThue[$scope.itemHachToanSelect].ma_ncc = ncc.MA_NHA_CUNG_CAP;
        };

        function errorAlert(message) {
            alert(message);
        }

        function beforeSave(callback) {
            var info = $scope.info;
            var listHachToan = $scope.listHachToan;
            var listThue = $scope.listThue;
            var listChungTu = $scope.arrayCTTC;

            if(!info.so_tai_khoan) {
                return callback('Thiếu thông tin Tài Khoản Chi');
            }

            if(!info.noi_dung_thanh_toan) {
                return callback('Thiếu thông tin Nội Dung Thanh Toán');
            }

            if(!info.ma_doi_tuong) {
                return callback('Thiếu thông tin Đối Tượng');
            }

            if(!info.ncc_so_tai_khoan) {
                return callback('Thiếu thông tin Tài Khoản Nhận');
            }

            if(!info.nhan_vien_thu || !info.nhan_vien_thu.USERNAME) {
                return callback('Thiếu thông tin Nhân Viên');
            }

            if(!info.nguoi_lap_bieu || !info.nguoi_lap_bieu.USERNAME) {
                return callback('Thiếu thông tin Người Lập Biểu');
            }

            if(!info.ngay_hach_toan) {
                return callback('Thiếu thông tin Ngày Hạch Toán');
            }

            if(!info.ngay_chung_tu) {
                return callback('Thiếu thông tin Ngày Chứng Từ');
            }

            if (info.ngay_hach_toan < info.ngay_chung_tu) {
                alert('Ngày Hạch Toán phải lớn hơn hoặc bằng Ngày Chứng Từ');
                return;
            }

            

            /*{
                dien_giai: null,
                tk_no: null,
                tk_co: null,
                so_tien: 0,
                quy_doi: 0,
                don_vi: null, // loại tiền
                ty_gia: 0
            };*/

            var tongtien = 0;
            if (listHachToan.length === 0) {
                callback('Thiếu thông tin danh sách hạch toán');
                return;
            }

            var tongtien = 0;
            for (var i = 0; i < listHachToan.length; i++) {
                var hachtoan = listHachToan[i];


                if (!hachtoan.don_vi) {
                    callback('Thiếu thông tin hạch toán Loại Tiền - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                if (!hachtoan.tk_no) {
                    callback('Thiếu thông tin hạch toán Tài Khoản Nợ - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                if (!hachtoan.tk_co) {
                    callback('Thiếu thông tin hạch toán Tài Khoản Có - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                if (!hachtoan.so_tien) {
                    callback('Thiếu thông tin hạch toán Số Tiền - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                if (hachtoan.don_vi == 'VND') {
                    hachtoan.ty_gia = 1;
                }

                if (!hachtoan.ty_gia) {
                    callback('Thiếu thông tin hạch toán Tỷ Giá - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                if (!hachtoan.dien_giai) {
                    callback('Thiếu thông tin hạch toán Diễn Giải - Bảng Diễn Giải hàng ' + (i + 1));
                    return;
                }

                var quy_doi = hachtoan.so_tien * hachtoan.ty_gia;
                tongtien += quy_doi;
            }

            /*{
                dien_giai: null,
                tk_thue: null,
                tien_thue: null,
                phan_tram_thue: 0,
                gia_tri_chua_thue: null,
                ngay_hoa_don: null,
                so_hoa_don: null,
                mau_so_hd: null,
                ky_hieu_hd: null,
                ma_ncc: null
            }*/

            /*if (info.noi_dung_thanh_toan === "Chi khác") {
                for (var i = 0; i < listThue.length ; i++) {
                    var thue = listThue[i];


                    if (!thue.dien_giai) {
                        callback('Thiếu thông tin thuế Diễn Giải Thuế - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.tk_thue) {
                        callback('Thiếu thông tin thuế Tài Khoản Thuế GTGT - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.tien_thue) {
                        callback('Thiếu thông tin thuế Tiền Thuế GTGT - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.phan_tram_thue) {
                        callback('Thiếu thông tin thuế % Thuế GTGT - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.gia_tri_chua_thue) {
                        callback('Thiếu thông tin thuế Giá Trị HHDV Chưa Thuế - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.ngay_hoa_don) {
                        callback('Thiếu thông tin thuế Ngày Hóa Đơn - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.so_hoa_don) {
                        callback('Thiếu thông tin thuế Số Hóa Đơn - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.mau_so_hd) {
                        callback('Thiếu thông tin thuế Mẫu Số HD - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.ky_hieu_hd) {
                        callback('Thiếu thông tin thuế Ký Hiệu HD - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }

                    if (!thue.ma_ncc) {
                        callback('Thiếu thông tin thuế Mã NCC - Bảng Diễn Giải hàng ' + (i + 1));
                        return;
                    }
                }
            }*/

            var NH_Phieu_Chi = {
                NGAY_HACH_TOAN: info.ngay_hach_toan.format('YYYY-MM-DD'),
                NGAY_CHUNG_TU: info.ngay_chung_tu.format('YYYY-MM-DD'),
                TAI_KHOAN_CHI: info.so_tai_khoan,
                MA_DOI_TUONG: info.ma_doi_tuong,

                NOI_DUNG_THANH_TOAN: info.noi_dung_thanh_toan,
                DIEN_GIAI_NOI_DUNG_THANH_TOAN: info.dien_giai_noi_dung_thanh_toan,
                TAI_KHOAN_NHAN: info.ncc_so_tai_khoan,
                NHAN_VIEN_CHUYEN_KHOAN: info.nhan_vien_thu.USERNAME,
                NGUOI_LAP_BIEU: info.nguoi_lap_bieu.USERNAME,
                TONG_TIEN: tongtien,
                TRUC_THUOC: info.ma_cong_ty
            }

            var NH_Ct_Phieu_Chis = [];
            for (var i = 0; i < listHachToan.length; i++) {
                var hachtoan = listHachToan[i];

                var tt_hachtoan = {
                    DIEN_GIAI: hachtoan.dien_giai,
                    LOAI_TIEN: hachtoan.don_vi,
                    TY_GIA: hachtoan.ty_gia,
                    TK_NO: hachtoan.tk_no,
                    TK_CO: hachtoan.tk_co,
                    SO_TIEN: hachtoan.so_tien,
                    QUY_DOI: hachtoan.so_tien * hachtoan.ty_gia,
                    MA_DOI_TUONG: info.ma_doi_tuong,
                    DON_VI: info.nhan_vien_thu.MA_PHONG_BAN
                }

                var thue = listThue[i];

                if (info.noi_dung_thanh_toan === 'Chi khác') {
                    var thue = listThue[i];
                    var tt_thue = {};

                    if (thue.dien_giai) {
                        tt_thue.DIEN_GIAI_THUE = thue.dien_giai;
                    }

                    if (thue.tk_thue) {
                        tt_thue.TK_THUE_GTGT = thue.tk_thue;
                    }

                    if (thue.tien_thue) {
                        tt_thue.TIEN_THUE_GTGT = thue.tien_thue;
                    }

                    if (thue.phan_tram_thue) {
                        tt_thue.CK_THUE_GTGT = thue.phan_tram_thue;
                    }

                    if (thue.gia_tri_chua_thue) {
                        tt_thue.GIA_TRI_HHDV_CHUA_THUE = thue.gia_tri_chua_thue;
                    }

                    if (thue.ngay_hoa_don) {
                        tt_thue.NGAY_HD = thue.ngay_hoa_don.format('YYYY-MM-DD');
                    }

                    if (thue.so_hoa_don) {
                        tt_thue.SO_HD = thue.so_hoa_don;
                    }

                    if (thue.mau_so_hd) {
                        tt_thue.MAU_SO_HD = thue.mau_so_hd;
                    }

                    if (thue.ky_hieu_hd) {
                        tt_thue.KY_HIEU_HD = thue.ky_hieu_hd;
                    }

                    if (thue.ma_ncc) {
                        tt_thue.MA_NHA_CUNG_CAP = thue.ma_ncc;
                    }

                    Object.assign(tt_hachtoan, tt_thue);
                }

                NH_Ct_Phieu_Chis.push(tt_hachtoan);
            }

            var tham_chieu = [];

            for (var i = 0; i < listChungTu.length; i++) {
                var _tc = {
                    SO_CHUNG_TU_THAM_CHIEU: listChungTu[i].ma_chung_tu
                }
                tham_chieu.push(_tc);
            }

            callback(null, NH_Phieu_Chi, NH_Ct_Phieu_Chis, tham_chieu);
        }

        $scope.save = function() {
            beforeSave(function(err, nH_UNC, nH_CT_UNCs, nH_CTTCs ) {
                if (err) {
                    return errorAlert(err);
                }

                console.log('nH_UNC', nH_UNC);
                console.log('nH_CT_UNCs', nH_CT_UNCs);
                console.log('nH_CTTCs', nH_CTTCs);

                function success(response) {
                    alert("Tạo chứng từ thành công");
                }

                function error(response) {
                    alert("Tạo chứng từ thất bại");
                }

                DataService.postNhUnc({
                    nH_UNC: nH_UNC, 
                    nH_CT_UNCs: nH_CT_UNCs,
                    nH_CTTCs: nH_CTTCs
                }, success, error, $('#container'));
                
            });
        };

        $scope.cancel = function() {
            initValue();

        };

/*		(function getNoiDungThanhToan()  {
            var data = {};
            $scope.listNoiDungTT = [];

            function success(response) {
                $scope.listNoiDungTT = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getNoiDungThanhToan(data, success, error, $('#container'));
        })();*/

        (function getDmTaiKhoanHachToan() {
            var data = {};
            $scope.listDmTaiKhoanHachToan = [];

            function success(response) {
                $scope.listDmTaiKhoanHachToan = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getDmTaiKhoanHachToan(data, success, error, $('#container'));
        })();

        (function getCctcFullNhanVien() {
            var data = {};
            $scope.listStaff = [];

            function success(response) {
                $scope.listStaff = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getCctcFullNhanVien(data, success, error, $('#container'));
        })();

        (function getNcc() {
            var data = {};
            $scope.listNCC = [];

            function success(response) {
                $scope.listNCC = response.data;
            }

            function error(response) {
                console.log(response);
            }
            
            DataService.getNcc(data, success, error, $('#container'));
        })();

        (function getTaiKhoanDinhKhoanTuDong() {
            //$scope.listNCC = [];

            function success(response) {
                $scope.dinh_khoan_tu_dong = response.data;
            }

            function error(response) {
                //console.log(response);
            }
            
            DataService.getTaiKhoanDinhKhoanTuDong('UNC', success, error, $('#container'));
        })();
    }
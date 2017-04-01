

    app.controller('ctrlCTTC', ctrlCTTC);
    function ctrlCTTC($scope, $http, $uibModalInstance, items) {
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

        $scope.optionGameValue = function () {

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
            switch ($scope.loaichungtu) {
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
        $scope.getDataDoTuong = function () {
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
            let t_index = $scope.chung_tu_selected.findIndex(function (item) {
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


<style scoped>
.isHide {
  display: none;
}
.m-dialog {
  z-index: 999;
}

.dialog-header {
  position: relative;
  padding-left: 32px;
  padding-top: 20px;
  display: flex;
  font-size: 23px;
}

.dialog-header-title {
  font-family: "MISA-Bold";
  font-size: 24px;
  color: #111;
  font-weight: 700;
}

.dialog-header-close {
  position: absolute;
  right: 12px;
  top: 12px;
}
.dialog-modal {
  position: fixed;
  top: 0;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: black;
  opacity: 0.4;
  z-index: inherit;
}

.dialog-content {
  position: fixed;
  width: 900px;
  background-color: #fff;
  left: calc(50% - 450px);
  top: calc(50% - 314px);
  z-index: inherit;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
}

.dialog-content .divide {
  width: 836px;
  border-top: 1px solid #e0e0e0;
  position: relative;
  left: 32px;
}
.dialog-body {
  padding: 0px 32px 53px 32px;
  font-family: "MISA-SemiBold";
}
.dialog-footer {
  width: 100%;
  height: 77px;
  background-color: #fff;
  border-radius: 0 0 5px 5px;
  padding: 20px 32px;
  box-sizing: border-box;
}

.label-required {
  color: red;
}
.label-input {
  margin-bottom: 0px;
  margin-top: 1rem;
}

.btn-save-form {
  background-color: #01b075;
  color: white;
  margin-left: 15px;
}
.input-warning {
  border-color: red !important;
}
.alertToggle {
  display: none;
  align-items: center;
  float: right;
  right: 16px;
  top: -22px;
  z-index: 1000;
}

.alertToggleName {
  position: absolute;
  align-items: center;
  float: right;
  z-index: 1000;
  background: black;
  color: white;
  padding: 2px 5px 2px 5px;
  right: 35px;
  top: 63px;
}

.alertToggleCode {
  width: max-content;
  position: absolute;
  align-items: center;
  float: right;
  z-index: 1000;
  background: black;
  color: white;
  padding: 2px 5px 2px 5px;
  right: -20px;
  top: 63px;
}

.alertToggleDepartment {
  position: absolute;
  align-items: center;
  float: right;
  z-index: 1000;
  background: black;
  color: white;
  padding: 2px 5px 2px 5px;
  right: 70px;
  top: 63px;
}

.textAlert {
  font-family: "MISA-Regular";
  /* margin-right: 20px; */
}
.textAlertName {
  font-family: "MISA-Regular";
  /* margin-right: 20px; */
}

.cb-checkbox {
  width: 18px;
  height: 18px;
  border-radius: 2px;
  border: 1px solid #afafaf;
}
.checkbox-input-form {
  display: flex;
  align-items: center;
  padding: 0px 1.5rem 0px 1.5rem;
}
.checkbox-input-form span {
  font-size: 13px;
  padding-left: 10px;
}

.icon.icon-close {
  width: 24px;
  height: 24px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -144px -144px;
}

.icon.icon-help {
  margin-right: 6px;
  width: 24px;
  height: 24px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -89px -144px;
}

.dialog-body .col-5,
.dialog-body .col-7,
.dialog-body .col,
.dialog-body .col-3 {
  padding-right: 3px;
  padding-left: 3px;
}

.dialog-body .avatar-employee {
  padding-left: 27px;
  padding-right: 35px;
}
.contain-radio-gender {
  height: 38px;
  display: flex;
  padding-left: 10px;
}

.contain-radio-gender input {
  height: 18px;
  width: 18px;
}
.form-control {
  font-size: 13px !important;
  font-family: "MISA-Regular";
}
.dialog-footer-left {
  float: left;
}
.dialog-footer-right {
  float: right;
}
.btn-detail-dialog {
  height: 36px;
  border: 1px solid #8d9096;
  color: #111;
  background-color: transparent;
  border-radius: 3px;
  font-size: 13px;
  padding: 8px 20px;
  background: #fff;
}
.btn-detail-dialog:hover {
  background: #d8d9db;
}
.second-right-button {
  font-family: "MISA-Bold";
  color: #fff;
  background: #248b15;
}
.second-right-button:hover {
  background: #35bf22;
  color: #fff;
}
.form-input-employee {
  padding-right: 26px;
}
input:focus,
textarea:focus,
select:focus {
  border-color: #2ca01c;
  -webkit-box-shadow: none;
  box-shadow: none;
}
</style>
<template>
  <div>
    <div
      class="m-dialog dialog-detail"
      title="Thông tin nhân viên"
      :class="{ isHide: isHide }"
    >
      <div class="dialog-modal"></div>
      <div class="alert alert-danger alertToggle" id="alert">
        <span class="textAlert">data was saved</span>
        <a href="#" class="close" data-dismiss="alert">&times;</a>
      </div>
      <div class="dialog-content">
        <div class="dialog-header">
          <div class="dialog-header-title">Thông tin nhân viên</div>
          <div class="checkbox-input-form">
            <input type="checkbox" class="cb-checkbox" />
            <span>Là khách hàng</span>
          </div>
          <div class="checkbox-input-form">
            <input type="checkbox" class="cb-checkbox" />
            <span>Là nhà cung cấp</span>
          </div>
          <div class="dialog-header-close">
            <button type="button" class="close" v-on:click="btnCancelOnClick">
              <div class="icon icon-close"></div>
            </button>
            <button type="button" class="close">
              <div class="icon icon-help"></div>
            </button>
          </div>
        </div>
        <div class="dialog-body">
          <div class="row">
            <div class="col-6 avatar-employee">
              <div class="row">
                <div class="col-5">
                  <label class="label-input">
                    Mã <span class="label-required">*</span>
                  </label>
                  <div class="input-group">
                    <input
                      id="txtEmployeeCode"
                      fieldName="EmployeeCode"
                      required
                      class="form-control require-not-null"
                      type="text"
                      v-model="employee.EmployeeCode"
                    />
                  </div>
                  <div class="alertToggleCode" style="display: none">
                    <span class="textAlertName"
                      >Mã nhân viên không được để trống</span
                    >
                  </div>
                </div>
                <div class="col-7">
                  <label class="label-input">
                    Tên <span class="label-required">(*)</span>
                  </label>
                  <div class="input-group">
                    <input
                      id="txtFullName"
                      fieldName="FullName"
                      class="form-control require-not-null"
                      type="text"
                      required
                      v-model="employee.EmployeeName"
                    />
                  </div>
                  <div class="alertToggleName" style="display: none">
                    <span class="textAlertName">Tên không được để trống.</span>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <label class="label-input">
                    Đơn vị <span class="label-required">(*)</span>
                  </label>
                  <div class="input-group">
                    <select
                      id="cbnDepartment"
                      fieldName="CustomerGroupName"
                      fieldValue="CustomerGroupId"
                      api="/api/customergroups"
                      class="form-control require-not-null"
                      v-model="employee.DepartmentId"
                    >
                      <option
                        v-for="department in departments"
                        :key="department.DepartmentId"
                        :value="department.DepartmentId"
                      >
                        {{ department.DepartmentName }}
                      </option>
                    </select>
                  </div>
                  <div class="alertToggleDepartment" style="display: none">
                    <span class="textAlertName">Chưa chọn đơn vị.</span>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <label class="label-input"> Chức danh </label>
                  <div class="input-group">
                    <input
                      class="form-control"
                      id="txtPositionName"
                      fieldName="text"
                      type="text"
                      required
                      v-model="employee.EmployeePosition"
                    />
                  </div>
                </div>
              </div>
            </div>
            <div class="col-6 form-input-employee">
              <div class="row">
                <div class="col-5">
                  <label class="label-input">Ngày sinh</label>
                  <div class="input-group">
                    <input
                      id="dtDateOfBirth"
                      class="form-control"
                      type="date"
                      v-model="employee.DateOfBirth"
                      min="1900-01-01"
                    />
                  </div>
                </div>
                <div class="col-7">
                  <label class="label-input"> Giới tính </label>
                  <div class="contain-radio-gender">
                    <div class="input-group">
                      <div class="form-check form-check-inline">
                        <input
                          class="form-check-input"
                          name="rd-gender"
                          type="radio"
                          id="rd-male"
                          value="1"
                          :checked="employee.gender === 1"
                        />
                        <label class="form-check-label">Nam</label>
                      </div>
                      <div class="form-check form-check-inline">
                        <input
                          class="form-check-input"
                          name="rd-gender"
                          type="radio"
                          id="rd-female"
                          value="0"
                          :checked="employee.gender === 0"
                        />
                        <label class="form-check-label">Nữ</label>
                      </div>
                      <div class="form-check form-check-inline">
                        <input
                          class="form-check-input"
                          name="rd-gender"
                          type="radio"
                          id="rd-other"
                          value="2"
                          :checked="employee.gender === 2"
                        />
                        <label class="form-check-label">Khác</label>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-7">
                  <label class="label-input"> Số CMND </label>
                  <div class="input-group">
                    <input
                      class="form-control"
                      id="txtIdentityNumber"
                      fieldName="text"
                      type="text"
                      required
                      v-model="employee.IdentityNumber"
                    />
                  </div>
                </div>
                <div class="col-5">
                  <label class="label-input">Ngày cấp</label>
                  <div class="input-group">
                    <input
                      id="dtDateOfBirth"
                      class="form-control"
                      type="date"
                      v-model="employee.IdentityDate"
                      min="1900-01-01"
                    />
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col">
                  <label class="label-input">Nơi cấp</label>
                  <div class="input-group">
                    <input
                      id="txtIdentityPlace"
                      fieldName="PhoneNumber"
                      class="form-control"
                      type="text"
                      v-model="employee.IdentityPlace"
                    />
                  </div>
                </div>
              </div>
            </div>
          </div>

          <div class="row" style="padding-top: 13px">
            <div class="col-12">
              <label class="label-input"> Địa chỉ </label>
              <div class="input-group">
                <input
                  id="txtAddress"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.Address"
                />
              </div>
            </div>
          </div>
          <div class="row" style="padding-left: 13px">
            <div class="col-3">
              <label class="label-input"> ĐT di động </label>
              <div class="input-group">
                <input
                  id="txtPhoneNumber"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.PhoneNumber"
                />
              </div>
            </div>
            <div class="col-3">
              <label class="label-input"> ĐT cố định </label>
              <div class="input-group">
                <input
                  id="txtCellPhone"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.TelephoneNumber"
                />
              </div>
            </div>
            <div class="col-3">
              <label class="label-input"> Email </label>
              <div class="input-group">
                <input
                  class="form-control"
                  id="txtEmail"
                  fieldName="Email"
                  type="email"
                  required
                  placeholder="example@domain.com"
                  v-model="employee.Email"
                />
              </div>
            </div>
          </div>
          <div class="row" style="padding-left: 13px">
            <div class="col-3">
              <label class="label-input"> Tài khoản ngân hàng </label>
              <div class="input-group">
                <input
                  id="txtBankNumber"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.BankAccountNumber"
                />
              </div>
            </div>
            <div class="col-3">
              <label class="label-input"> Tên ngân hàng </label>
              <div class="input-group">
                <input
                  id="txtBackName"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.BankName"
                />
              </div>
            </div>
            <div class="col-3">
              <label class="label-input"> Chi nhánh </label>
              <div class="input-group">
                <input
                  id="txtBankBranch"
                  fieldName="FullName"
                  class="form-control"
                  type="text"
                  required
                  v-model="employee.BankBranchName"
                />
              </div>
            </div>
          </div>
        </div>
        <div class="divide"></div>
        <div class="dialog-footer">
          <div class="dialog-footer-left">
            <button
              id="btnCancel"
              class="btn btn-default btn-detail-dialog"
              v-on:click="btnCancelOnClick"
            >
              Huỷ
            </button>
          </div>
          <div class="dialog-footer-right">
            <button
              id="btnSave"
              @click="saveEmployee"
              class="btn btn-save-form btn-detail-dialog"
            >
              <i class="far fa-save"></i><span class="btn-text">Cất</span>
            </button>
            <button
              id="btnSave"
              @click="saveEmployee"
              class="btn btn-save-form btn-detail-dialog btn second-right-button"
            >
              <i class="far fa-save"></i
              ><span class="btn-text">Cất và thêm</span>
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import * as axios from "axios";
import $ from "jquery";
export default {
  props: {
    isHide: Boolean,
    employee: Object,
    initEmployee: Function,
    showAlertData: Function,
    showAlertDuplicate: Function,
    requestStatus: Number,
    departments: Array,
    positions: Array,
  },
  methods: {
    // sự kiện đóng dialog input form
    btnCancelOnClick() {
      this.$emit("closePopup", true); //đóng dialog
      removeWarningEmpty(); // bỏ cảnh báo field input
      $(".alertToggleName").css("display", "none");
      $(".alertToggleDepartment").css("display", "none");
      $(".alertToggleCode").css("display", "none");
    },

    // tạo mới hoặc sửa thông tin nhân viên
    async saveEmployee() {
      var count = countEmpty(); // đếm số input bắt buộc không hợp lệ
      if (count === 0) {
        this.$emit("closePopup", true); //đóng dialog
        this.employee.DateOfBirth = validateDate(this.employee.DateOfBirth); // validate theo maxdate and mindate
        this.employee.gender = this.getValueGender();
        if (this.requestStatus == 0) {
          //0: thêm mới nhân viên
          await axios
            .post("https://localhost:44325/api/v1/Employees", this.employee)
            .then((res) => {
              console.log(res.data);
              this.showAlertData("Thêm mới nhân viên thành công");
            })
            .catch((err) => {
              this.showAlertDuplicate(this.employee.EmployeeCode);
              console.log(err);
            });
        } else {
          // sửa nhân viên
          await axios
            .put(
              "https://localhost:44325/api/v1/Employees/" +
                this.employee.EmployeeId,
              this.employee
            )
            .then((res) => {
              console.log(res.data);
              this.showAlertData("Sử thông tin mô nhân viên thành công");
            })
            .catch((err) => {
              this.showAlertDuplicate(this.employee.EmployeeCode);
              console.log(err);
            });
        }
        await this.initEmployee(); // cập nhật lại dự liệu
      } else {
        warningEmpty(); // cảnh báo các field input chưa hợp lệ
        if (!$("#txtFullName").val()) {
          $(".alertToggleName").css("display", "block");
        }
        if (!$("#txtEmployeeCode").val()) {
          $(".alertToggleCode").css("display", "block");
        }
        if (!$("#cbnDepartment").val()) {
          $(".alertToggleDepartment").css("display", "block");
        }
      }
    },

    //lấy value gender
    getValueGender() {
      return $("input[name='rd-gender']:checked").val();
    },
  },

  data() {
    return {};
  },
};

$(document).ready(function () {
  // set max date in datetimePicker
  $("#dtDateOfBirth").prop("max", getMaxDate());

  // check input hợp lệ với sự kiện khi tab hoặc click ra khỏi field input
  $(document).on("blur", "#txtFullName", function () {
    // họ tên
    if (!$(this).val()) {
      $(this).addClass("input-warning");
    } else {
      $(this).removeClass("input-warning");
    }
  });

  // txtEmployeeCode
  $(document).on("blur", "#txtEmployeeCode", function () {
    if (!$(this).val()) {
      $(this).addClass("input-warning");
    } else {
      $(this).removeClass("input-warning");
    }
  });

  $(document).on("click", "#cbnDepartment", function () {
    if (!$(this).val()) {
      $(this).addClass("input-warning");
    }
  });

  $(document).on("blur", "#dtDateOfBirth", function () {
    // ngày sinh
    const a = validateDate($(this).val());
    $(this).val(a); //nếu cố tình nhập thời gian vượt quá khoảng min max thì set lại giá trị min hoặc max
  });

  $(document).on("change", "#cbnDepartment", function () {
    $(this).removeClass("input-warning");
  });

  //Họ tên
  $(document).on("keydown", "#txtFullName", function () {
    $(this).removeClass("input-warning");
    $(".alertToggleName").css("display", "none");
  });

  $("#txtFullName").hover(
    function () {
      if (!$(this).val() && $(this).hasClass("input-warning")) {
        $(".alertToggleName").css("display", "block");
      }
    },
    function () {
      $(".alertToggleName").css("display", "none");
    }
  );

  // mã nhân viên
  $(document).on("keydown", "#txtEmployeeCode", function () {
    $(this).removeClass("input-warning");
    $(".alertToggleCode").css("display", "none");
  });

  $("#txtEmployeeCode").hover(
    function () {
      if (!$(this).val() && $(this).hasClass("input-warning")) {
        $(".alertToggleCode").css("display", "block");
      }
    },
    function () {
      $(".alertToggleCode").css("display", "none");
    }
  );

  $("#cbnDepartment").hover(
    function () {
      if (!$(this).val() && $(this).hasClass("input-warning")) {
        $(".alertToggleDepartment").css("display", "block");
      }
    },
    function () {
      $(".alertToggleDepartment").css("display", "none");
    }
  );
});

// đếm field input trống và dữ liệu không hợp lệ
function countEmpty() {
  let count = 0;
  $(document)
    .find(".require-not-null")
    .each(function () {
      console.log($(this).val());
      if (!$(this).val()) {
        count++;
      }
    });

  return count;
}

// cảnh báo các field input trống
function warningEmpty() {
  $(".dialog-detail")
    .find(".require-not-null")
    .each(function () {
      if (!$(this).val()) {
        $(this).addClass("input-warning");
      }
    });
}

// xóa cảnh báo các field input trống
function removeWarningEmpty() {
  $(document).find(".input-warning").removeClass("input-warning");
}

// validate range date
function validateDate(date) {
  return date < $("#dtDateOfBirth").prop("min")
    ? $("#dtDateOfBirth").prop("min")
    : date > getMaxDate()
    ? getMaxDate()
    : date;
}

// lấy ngày hiện tại
function getMaxDate() {
  let date = new Date();
  let month = date.getMonth() + 1;
  let day = date.getDate();
  let dateNow =
    date.getFullYear() +
    "-" +
    (month < 10 ? "0" : "") +
    month +
    "-" +
    (day < 10 ? "0" : "") +
    day;

  return dateNow;
}
</script>

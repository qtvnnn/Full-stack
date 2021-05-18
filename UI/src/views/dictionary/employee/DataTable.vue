<template>
  <div class="content">
    <BaseLoading :showLoading="isLoading" />
    <div class="content-header">
      <div class="content-header-left">
        <span class="menu-item-selected">Nhân viên</span>
      </div>
      <div class="content-header-right">
        <a
          class="btn btn-add-employee"
          role="button"
          v-on:click="btnAddOnClick"
        >
          <div class="item-name">Thêm mới nhân viên</div>
        </a>

        <div class="alert alert-success alertToggleData" id="alert">
          <span class="textAlertData">data was saved</span>
          <a href="#" class="close" data-dismiss="alert">&times;</a>
        </div>
      </div>
    </div>
    <div class="customer-filter">
      <div class="customer-filter-left"></div>
      <div class="customer-filter-right">
        <div class="input-search">
          <input
            type="text"
            class="txtInput-search"
            aria-label="Username"
            aria-describedby="basic-addon1"
            v-on:keyup.13="filterInput($event)"
            placeholder="Tìm theo mã, tên nhân viên"
          />
          <div class="icon icon-input-search"></div>
        </div>
        <a class="btn btn-reset-filter" href="#" v-on:click="btnResetTable">
          <div class="icon icon-reset-filter"></div>
        </a>
      </div>
    </div>
    <div class="data-table" style="display: -webkit-box">
      <div class="border-right-table-3"></div>
      <table
        class="table"
        width="100%"
        border="0"
        style="
          width: max-content;
          background: rgb(255, 255, 255);
          border-collapse: separate;
          border-spacing: 0px;
          margin-bottom: 3rem;
        "
      >
        <thead>
          <tr>
            <th class="first-column column-select-all" style="z-index: 2">
              <input type="checkbox" class="checkbox-select-item" />
            </th>
            <th style="width: 150px">MÃ NHÂN VIÊN</th>
            <th style="width: 250px">TÊN NHÂN VIÊN</th>
            <th style="width: 120px">GIỚI TÍNH</th>
            <th style="width: 150px">NGÀY SINH</th>
            <th style="width: 200px">SỐ CMND</th>
            <th style="width: 250px">CHỨC DANH</th>
            <th style="width: 250px">TÊN ĐƠN VỊ</th>
            <th style="width: 150px">SỐ TÀI KHOẢN</th>
            <th style="width: 200px">TÊN NGÂN HÀNG</th>
            <th style="width: 250px">CHI NHÁNH TK NGÂN HÀNG</th>
            <th
              class="last-column"
              style="z-index: 2; border-left: 1px solid #c7c7c7"
            >
              CHỨC NĂNG
            </th>
          </tr>
        </thead>
        <tbody>
          <tr v-for="(employee, index) in employees" :key="employee.EmployeeId">
            <td class="first-column">
              <input type="checkbox" class="checkbox-select-item" />
            </td>
            <td>{{ employee.EmployeeCode }}</td>
            <td>{{ employee.EmployeeName }}</td>
            <td>{{ genderString(employee.gender) }}</td>
            <td style="text-align: center">
              {{ employee.DateOfBirth | formatDate }}
            </td>
            <td>{{ employee.IdentityNumber }}</td>
            <td>{{ employee.EmployeePosition }}</td>
            <td>{{ employee.DepartmentName }}</td>
            <td>{{ employee.BankAccountNumber }}</td>
            <td>
              {{ employee.BankName }}
            </td>
            <td>{{ employee.BankBranchName }}</td>
            <td class="column-function last-column">
              <div class="contain-btn-funtion">
                <div class="btn-table-edit" v-on:click="rowOnClick(employee)">
                  <span>Sửa</span>
                </div>
                <div class="contain-icon-dropdown">
                  <div class="dropdown">
                    <div
                      class="icon dropdown-icon"
                      type="button"
                      id="dropdownMenuButton"
                      data-toggle="dropdown"
                      aria-haspopup="true"
                      aria-expanded="false"
                    ></div>
                    <div
                      class="dropdown-menu"
                      aria-labelledby="dropdownMenuButton"
                    >
                      <a class="dropdown-item" href="#">Nhân bản</a>
                      <a
                        class="dropdown-item"
                        href="#"
                        data-toggle="modal"
                        :data-target="'#exampleModal' + index"
                        >Xoá</a
                      >
                      <a class="dropdown-item" href="#">Ngừng sử dụng</a>
                    </div>
                  </div>
                </div>
              </div>

              <!-- Modal -->
              <div
                class="modal modal-style fade"
                :id="'exampleModal' + index"
                tabindex="-1"
                role="dialog"
                aria-labelledby="exampleModalLabel"
                aria-hidden="true"
              >
                <div class="modal-dialog" role="document">
                  <div class="modal-content">
                    <div class="modal-body">
                      <div class="icon warning-icon-delete"></div>
                      <span class="model-messagle">
                        Bạn có thực sự muốn xoá nhân viên &lt;{{
                          employee.EmployeeCode
                        }}&gt; không?
                      </span>
                    </div>
                    <div class="modal-header-line"></div>
                    <div class="modal-footer">
                      <button
                        type="button"
                        class="btn btn-confirm btn-closeNo"
                        data-dismiss="modal"
                      >
                        Không
                      </button>
                      <button
                        type="button"
                        class="btn btn-confirm btn-confirm-delete"
                        data-dismiss="modal"
                        v-on:click="deleteEmployee(employee.EmployeeId)"
                      >
                        Có
                      </button>
                    </div>
                  </div>
                </div>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
      <div class="border-right-table-1"></div>
      <div class="border-right-table-2"></div>
    </div>

    <!-- Modal 2 -->
    <div id="alertDuplicate" class="modal modal-style" style="display: none">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-body">
            <div class="icon warning-icon-delete"></div>
            <span class="model-messagle-duplicate">
              Nhân viên &lt;<span id="employeeCodeDuplicate">x</span>&gt; đã tồn
              tại trong hệ thống. vui lòng kiểm tra lại.
            </span>
          </div>
          <div class="modal-header-line"></div>
          <div class="modal-footer">
            <button
              type="button"
              class="btn btn-confirm btn-confirm-duplicate"
              v-on:click="closeAlertDuplicate()"
            >
              Đồng ý
            </button>
          </div>
        </div>
      </div>
    </div>

    <footer class="footer-table">
      <div class="footer-table-left">
        <span class="text-muted"
          >Tổng số: <b class="total-record"></b> bản ghi</span
        >
      </div>
      <div class="footer-table-right">
        <div class="combobox-footer">
          <input
            type="text"
            class="combobox-text"
            readonly
            value="20 bản ghi trên 1 trang"
          />
          <div class="btn-dropdown">
            <div class="icon-btn-dropdown"></div>
          </div>
        </div>
        <span class="previous-paging disableText">Trước</span>
        <div class="paging-index">
          <span class="paging-index-item pageSelected">1</span>
          <span class="paging-index-item">2</span>
          <span class="paging-index-item">3</span>
          <span class="paging-index-item">...</span>
          <span class="paging-index-item">53</span>
        </div>
        <span class="next-paging" v-on:click="toTop()">Sau</span>
      </div>
    </footer>
    <Details
      @closePopup="closePopup"
      :isHide="isHideParent"
      :employee="selectedEmployee"
      :initEmployee="initEmployee"
      :showAlertData="showAlertData"
      :showAlertDuplicate="showAlertDuplicate"
      :requestStatus="requestStatus"
      :departments="departments"
    />
  </div>
</template>

<script>
import * as axios from "axios";
import $ from "jquery";
import Details from "./FormDetail.vue";
import BaseLoading from "../../../components/base/BaseLoading";
export default {
  name: "Content",
  components: {
    Details,
    BaseLoading,
  },
  methods: {
    toTop() {
      $(".content").animate({ scrollTop: 0 }, 1);
      $(".content").animate({ scrollLeft: 0 }, 1);
    },
    // sự kiện click làm mới dữ liệu trong table
    async btnResetTable() {
      this.toTop();
      await this.initEmployee();
    },

    // sự kiện click hiện dialog form input để thêm mới nhân viên
    async btnAddOnClick() {
      this.requestStatus = 0;
      this.isHideParent = false;
      this.selectedEmployee = {};
      this.selectedEmployee = {
        EmployeeCode: await this.getNewEmployeeCode(),
        WorkStatus: 0,
        Gender: 1,
        DepartmentId: "",
      };
      $("#txtEmployeeCode").focus();
    },

    // sự kiện ấn nút Sửa để hiện thông tin chi tiết một nhân viên trên dialog input form
    rowOnClick(employee) {
      if (employee.DateOfBirth != null) {
        employee.DateOfBirth = this.formatDateToForm(employee.DateOfBirth);
      }
      if (employee.IdentityDate != null) {
        employee.IdentityDate = this.formatDateToForm(employee.IdentityDate);
      }
      this.requestStatus = 1;
      this.selectedEmployee = employee;
      this.isHideParent = false;
    },

    // thay đổi trạng thái đóng mở dialog input form
    async closePopup(value) {
      this.isHideParent = value;
    },

    // gọi api load dữ liệu
    async initEmployee() {
      this.toTop();
      this.isLoading = true;

      // get all employee
      await axios
        .get("https://localhost:44325/api/v1/Employees/EmployeesWithDepartment")
        .then((res) => {
          this.employees = res.data;
          $(".total-record").text(res.data.length);
        });

      // get all department
      await axios
        .get("https://localhost:44325/api/v1/Departments")
        .then((res) => {
          this.departments = res.data;
        });

      this.isLoading = false;
    },

    // sự kiện gọi api xóa một bản ghi nhân viên
    async deleteEmployee(employeeId) {
      const response = await axios.delete(
        "https://localhost:44325/api/v1/Employees/" + employeeId
      );
      console.log(response);
      this.showAlertData("Xóa một bản ghi nhân viên thành công");
      await this.initEmployee();
    },

    // gọi api lấy mã nhân viên mới
    async getNewEmployeeCode() {
      const newEmployeeCodeAPI = await axios.get(
        "https://localhost:44325/api/v1/Employees/newEmployeeCode"
      );
      return newEmployeeCodeAPI.data;
    },

    // gọi api filter để tìm kiếm nhân viên theo tên, mã nhân viên, sđt
    async getDataFilter(valueInput) {
      this.isLoading = true;

      await axios
        .get(
          `https://localhost:44325/api/v1/Employees/employeeFilter?search=${valueInput}`
        )
        .then((res) => {
          this.employees = res.data;
          console.log(res.data);
        })
        .catch((err) => {
          console.log(err);
        });

      this.isLoading = false;
    },

    // fix cứng value của trạng thái công việc
    genderString(gender) {
      switch (gender) {
        case 0:
          return "Nữ";
        case 1:
          return "Nam";
        case 2:
          return "Khác";
      }
    },

    // format ngày tháng năm để đúng định dạng insert
    formatDateToForm(dateString) {
      if (dateString !== null) {
        var res = dateString.split("-");
        var year = res[0];
        var month = res[1];
        var day = res[2].split("T")[0];
        return year + "-" + month + "-" + day;
      }
      return "";
    },

    // sự kiện filter theo tên, mã nhân viên, sđt
    async filterInput(txtInput) {
      let valueInput = txtInput.target.value;
      if (valueInput) {
        await this.getDataFilter(valueInput);
      } else {
        await this.initEmployee();
      }
    },

    // hiện alert thông báo
    showAlertData(alert) {
      $(".textAlertData").text(alert);
      setTimeout(function () {
        $(".alertToggleData")
          .css("display", "flex")
          .delay(4000)
          .fadeOut("slow");
      }, 1000);
    },

    //hiển thị thông báo lỗi trùng mã nhân viên khi thêm hoặc sửa
    showAlertDuplicate(code) {
      $(".content").css("overflow", "hidden");
      $("body").append(
        `<div id="operacyBody" class="modal-backdrop fade show"></div>`
      );
      setTimeout(function () {
        $("#alertDuplicate").css("display", "block");
      }, 1000);
      $("#employeeCodeDuplicate").text(code);
    },

    //event tắt thông báo trùng lỗi trùng mã nhân viên
    closeAlertDuplicate() {
      $(".content").css("overflow", "");
      $("#alertDuplicate").css("display", "none");
      $("#operacyBody").remove();
    },
  },

  data() {
    return {
      isLoading: false,
      employees: [],
      departments: [],
      selectedEmployee: {},
      isHideParent: true,
      requestStatus: 0,
    };
  },

  async created() {
    await this.initEmployee();
  },
};
</script>

<style scoped>
.content-header {
  height: 74px;
  width: 100%;
  background: #f4f5f6;
  padding-right: 30px;
  position: sticky;
  top: -1px;
  left: 0px;
  z-index: 999;
}
.content-header-left {
  float: left;
  padding-left: 20px;
  display: flex;
  align-items: center;
}
.content-header-left .menu-item-selected {
  font-size: 24px;
  font-family: "MISA-Bold" !important;
  color: #111;
  padding-top: 22px;
}
.content-header-right {
  float: right;
  display: flex;
  align-items: center;
  padding-top: 22px;
}

.content-header-right .btn-add-employee {
  background-color: #2ca01c;
  color: #fff;
  padding: 8px 14px 8px 20px;
  height: 36px;
  border: 1px solid transparent;
}
.content-header-right .btn-add-employee .item-name {
  font-family: "MISA-SemiBold" !important;
  position: relative;
  color: inherit;
  display: flex;
  transition: all 0.25s ease;
  white-space: nowrap;
  font-size: 13px;
  justify-content: center;
  align-items: center;
}
.content-header-right .btn-add-employee:hover {
  background-color: #35bf22;
}
.icon.arrow-up {
  width: 16px;
  height: 16px;
  margin: 0 10px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -848px -359px;
}
.icon.icon-input-search {
  width: 16px;
  height: 16px;
  margin: 0 10px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -992px -360px;
  cursor: pointer;
  position: absolute;
  left: auto;
  right: 5px;
  border-right: 0;
  padding-left: 3px;
  margin-right: 4px;
}
.input-search {
  display: flex;
  width: 240px;
  align-items: flex-start;
  flex-direction: column;
  position: relative;
  justify-content: center;
}
.input-search .txtInput-search {
  font-size: 13px;
  height: 32px;
  color: inherit;
  position: relative;
  padding: 6px 10px;
  border-radius: 2px;
  border: 1px solid #babec5;
  box-sizing: border-box;
  width: 100%;
}
.customer-filter {
  height: 72px;
  width: calc(100% - 30px);
  background: #fff;
  position: sticky;
  left: 0px;
}
.customer-filter-left {
  height: 50px;
  float: left;
  display: flex;
  align-items: center;
  padding-left: 20px;
}
.inputbox-filter {
  border-left: none !important;
}
.customer-filter-right {
  height: 50px;
  display: flex;
  align-items: center;
  float: right;
  padding-top: 16px;
}
.customer-filter-right .btn-reset-filter {
  background-color: #ffffff;
  padding-right: 16px;
}
.customer-filter-right .btn-reset-filter .icon-reset-filter {
  width: 24px;
  height: 24px;
  padding: 0 6px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -1097px -88px;
}
.data-table {
  height: fit-content;
  position: absolute;
  right: 30px;
  left: 0px;
  bottom: 60px;
  top: 146px;
  background: #fff;
}
.data-table th {
  position: sticky;
  top: 72px;
  background-color: white;
  font-size: 12px;
  text-transform: uppercase !important;
  align-items: center;
  cursor: pointer;
  padding: 7px 10px 7px 10px;
  border-right: 1px solid #c7c7c7;
  border-bottom: 1px solid #c7c7c7;
  background-color: #eceef1;
}
.data-table td {
  border-right: 1px dotted #c7c7c7;
}
.data-table tr {
  cursor: pointer;
}
.footer-table {
  position: sticky;
  bottom: 0;
  left: 0;
  width: 100%;
  height: 46px;
  line-height: 46px;
  background-color: #f4f5f6;
  top: calc(100% - 46px);
  z-index: 3;
}
.footer-table .row {
  width: 100% !important;
  margin: 0;
}
.footer-table-left {
  text-align: left;
  float: left;
  z-index: 999;
  position: sticky;
  width: calc(100% - 540px);
  background: #fff;
}
.footer-table-right {
  text-align: right;
  position: absolute;
  right: 30px;
  background: #fff;
  display: flex;
  padding-right: 60px;
}

.alertToggleData {
  position: absolute;
  display: none;
  align-items: center;
  top: 13px;
  right: 210px;
}
.textAlertData {
  margin-right: 20px;
}
.modal-footer {
  border-top: none;
  padding-top: 0px;
  padding-bottom: 32px;
}
.modal-body {
  display: flex;
  padding: 32px 32px 32px 32px;
}

.modal-body .model-messagle {
  display: flex;
  align-items: center;
  padding-left: 16px;
  padding-top: 12px;
}

.modal-body .model-messagle-duplicate {
  align-items: center;
  padding-left: 16px;
  padding-top: 12px;
}

.btn-closeNo {
  background: #ffffff;
  color: #111;
  border: 1px solid #8d9096;
  border-radius: 3px;
  position: relative;
  right: 118px;
}
.btn-closeNo:hover {
  background: #d2d3d6;
  color: #3d3f4e;
  border-radius: 4px;
  cursor: pointer;
}
.btn-confirm-delete {
  background: #2ca01c;
  color: #ffffff;
  border-radius: 4px;
  position: relative;
  left: 105px;
}
.btn-confirm-duplicate {
  background: #2ca01c;
  color: #ffffff;
  border-radius: 4px;
  position: relative;
  left: 140px;
}
.btn-confirm-delete:hover,
.btn-confirm-duplicate:hover {
  background: #33b921;
  color: #ffffff;
  border-radius: 4px;
  cursor: pointer;
}

.btn-confirm {
  margin: 0px 0px 0px 15px;
  padding: 8px 20px;
  font-size: inherit;
  font-family: "MISA-SemiBold";
}
.modal-style {
  cursor: default;
}
.text-muted {
  color: #111 !important;
  padding-left: 20px;
}
.disableText {
  cursor: default !important;
  color: #9e9e9e;
}
.previous-paging {
  margin-right: 1rem;
  cursor: pointer;
}
.next-paging {
  margin-left: 1rem;
  cursor: pointer;
}
.paging-index-item {
  padding: 0rem 0.4rem;
  cursor: pointer;
}
.paging-index .pageSelected {
  border: 1px solid #e0e0e0;
  font-weight: 700;
}
.combobox-footer {
  position: relative;
  top: 7px;
  height: 50%;
  display: flex;
  min-height: 32px;
  border: 1px solid #babec5;
  border-radius: 2px;
  margin: 0 16px;
}
.combobox-footer .combobox-text {
  height: 100%;
  border: none;
  font-size: 13px;

  padding: 6px 0 6px 12px;
}

.combobox-footer .btn-dropdown {
  width: 32px;
  background-color: transparent;
  display: flex;
  align-items: center;
  justify-content: center;
  cursor: pointer;
}
.combobox-footer .btn-dropdown:hover {
  background: #e0e0e0;
}
.combobox-footer .btn-dropdown .icon-btn-dropdown {
  width: 16px;
  height: 16px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -560px -359px;
}

.btn-table-edit {
  color: #0075c0;
  padding: 6px 0 6px 16px !important;
  font-family: "MISA-SemiBold";
}
.btn-table-edit span:active {
  border: 1px solid #0075c0;
}
.btn-table-edit span {
  border: 1px solid #e9ecef0a;
}
.dropdown-icon:active {
  border: 1px solid #0075c0;
}
.column-function {
  padding: 5px 10px;
  /* position: sticky !important; */
  right: 50px;
  background: #fff;
  border-left: 1px solid #c7c7c7 !important;
}

.column-function .contain-icon-dropdown {
  padding: 8px 10px !important;
  position: relative;
  top: -2px;
}
.dropdown-icon {
  border: 1px solid #e9ecef0a;
}
.icon.dropdown-icon {
  padding: 8px 10px;
  width: 16px;
  height: 16px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -896px -359px;
}

.data-table tbody tr:hover {
  background: #f3f8f8;
}
.contain-icon-dropdown .dropdown-menu {
  transform: translate3d(-88px, 22px, 0px) !important;
  padding: 2px 1px;
  border-radius: 2px;
  min-width: none;
}

.contain-icon-dropdown .dropdown-item {
  font-size: 13px;
  padding: 5px;
  padding-left: 10px;
  padding-right: 10px;
  width: 100%;
}

.contain-icon-dropdown .dropdown-item:hover {
  color: #2ca01c;
}
.contain-icon-dropdown .dropdown-item:active {
  background: #e9ecef;
}
.modal-dialog {
  width: 444px;
  height: -webkit-fill-available;
  display: flex;
  align-items: center;
}

.modal-dialog .modal-content {
  border-radius: 3px;
  box-shadow: 0 5px 20px 0 rgb(0 0 0 / 10%);
  border: none;
  align-items: center;
}
.icon.warning-icon-delete {
  width: 48px;
  height: 48px;
  background: url("../../../assets/img/Sprites.64af8f61.svg") no-repeat -592px -456px;
}
.modal-header-line {
  height: 1px;
  background: #b8bcc3;
  margin-bottom: 20px;
  width: calc(100% - 64px);
}

.checkbox-select-item {
  width: 18px;
  height: 18px;
}
.first-column {
  /* position: absolute; */
  border-top: 1px solid #dee2e6;
  margin-top: 0px;
  z-index: 1;
  display: flex;
  text-align: center;
  justify-content: center;
}
.column-select-all {
  display: flex;
  align-items: center !important;
  justify-content: center;
  padding-left: 11.5px !important;
}
.last-column {
  border-right: none !important;
  z-index: 1;
  /* right: 55px; */
}

.contain-btn-funtion {
  display: flex;
  align-items: center;
  justify-content: center;
}
#alertDuplicate {
  position: relative;
  top: -97px;
  left: -95px;
}
.border-right-table-1 {
  width: 25px;
  height: auto;
  background: #fff;
  position: sticky;
  right: 30px;
  z-index: 1;
}
.border-right-table-2 {
  width: 30px;
  height: auto;
  background: #f4f5f6;
  position: sticky;
  right: 0;
  z-index: 1;
}

.border-right-table-3 {
  width: 20px;
  height: auto;
  background: #fff;
  position: sticky;
  left: 0;
  z-index: 3;
}

.modal-backdrop{
  display: none !important;
}
</style>

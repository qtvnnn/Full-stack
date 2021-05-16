<template>
  <div>
    <div class="sidebar">
      <div class="toggle"></div>
      <div class="logo">
        <img
          src="https://actappg2.misacdn.net/img/Logo_Module_TiengViet_White.66947422.svg"
          class="img-icon"
        />
      </div>
    </div>
    <div class="menu">
      <router-link class="menu-item" to="/about">
        <div class="icon-item-contain">
          <div class="icon overview"></div>
        </div>
        <div class="item-name">Tổng quan</div>
      </router-link>
      <router-link class="menu-item" to="/dictionary/employee">
        <div class="icon-item-contain">
          <div class="icon cash"></div>
        </div>
        <div class="item-name">Tiền mặt</div>
      </router-link>
      <router-link class="menu-item" to="/deposits">
        <div class="icon-item-contain">
          <div class="icon deposits"></div>
        </div>
        <div class="item-name">Tiền gửi</div>
      </router-link>
      <router-link class="menu-item" to="/purchase">
        <div class="icon-item-contain">
          <div class="icon list-purchase"></div>
        </div>
        <div class="item-name">Mua hàng</div>
      </router-link>
      <router-link class="menu-item" to="/sell"> <!-- sell -->
        <div class="icon-item-contain">
          <div class="icon list-sell"></div>
        </div>
        <div class="item-name">Bán hàng</div>
      </router-link>
      <router-link class="menu-item" to="/invoice">
        <div class="icon-item-contain">
          <div class="icon invoice"></div>
        </div>
        <div class="item-name">Quán lý hoá đơn</div>
      </router-link>
      <router-link class="menu-item" to="/warehouse">
        <div class="icon-item-contain">
          <div class="icon warehouse"></div>
        </div>
        <div class="item-name">Kho</div>
      </router-link>
      <router-link class="menu-item" to="/tools">
        <div class="icon-item-contain">
          <div class="icon tools"></div>
        </div>
        <div class="item-name">Công cụ dụng cụ</div>
      </router-link>
      <router-link class="menu-item" to="/assets">
        <div class="icon-item-contain">
          <div class="icon assets"></div>
        </div>
        <div class="item-name">Tài sản cố định</div>
      </router-link>
      <router-link class="menu-item" to="/tax">
        <div class="icon-item-contain">
          <div class="icon tax"></div>
        </div>
        <div class="item-name">Thuế</div>
      </router-link>
      <router-link class="menu-item" to="/price">
        <div class="icon-item-contain">
          <div class="icon price"></div>
        </div>
        <div class="item-name">Giá thành</div>
      </router-link>
      <router-link class="menu-item" to="/general">
        <div class="icon-item-contain">
          <div class="icon general"></div>
        </div>
        <div class="item-name">Tổng hợp</div>
      </router-link>
      <router-link class="menu-item" to="/budget">
        <div class="icon-item-contain">
          <div class="icon budget"></div>
        </div>
        <div class="item-name">Ngân sách</div>
      </router-link>
      <router-link class="menu-item" to="/report">
        <div class="icon-item-contain">
          <div class="icon report"></div>
        </div>
        <div class="item-name">Báo cáo</div>
      </router-link>
      <router-link class="menu-item" to="/analysis">
        <div class="icon-item-contain">
          <div class="icon financial-analysis"></div>
        </div>
        <div class="item-name">Phân tích tài chính</div>
      </router-link>
    </div>
  </div>
</template>

<script>
export default {
  name: "NavBar",
  props: {},
  methods: {},
};
</script>

<style scoped>
</style>

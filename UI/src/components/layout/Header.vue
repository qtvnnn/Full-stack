<template>
  <div class="header">
    <div class="header-left">
      <div class="header-title">
        <div class="icon overview"></div>
        <span class="header-title-text">CÔNG TY CỔ PHẦN MISA</span>
        <div class="icon chevron"></div>
        <div class="tooltip-content">
          <div class="header-current-db">
            <div class="icon-header-current-db"></div>
            <div class="header-current-db-name">DC-02</div>
          </div>
        </div>
      </div>
    </div>
    <div class="header-right">
      <div class="account">
        <div class="icon category"></div>
        <div class="icon setting"></div>
        <div class="icon chat"></div>
        <div class="icon simple-question"></div>
        <div class="icon bell"></div>
        <div class="account-info">
          <div class="account-info-contain">
            <div class="user-ava"></div>
            <span class="user-name">Nguyễn Ngọc Năng</span>
            <div class="icon account-chevron"></div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Header",
  props: {},
};
</script>

<style scoped>
</style>

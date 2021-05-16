<template>
  <div>
    <Loading
      :active.sync="showLoading"
      :loader="loader"
      :color="color"
      :height="height"
      :width="width"
      :on-cancel="onCancel"
      :opacity="opacity"
      :background-color="backgroundColor"
      :blur="blur"
      :is-full-page="fullPage"
    ></Loading>
  </div>
</template>
<script>
import Loading from "vue-loading-overlay";
import "vue-loading-overlay/dist/vue-loading.css";

export default {
  name: "BaseLoading",
  components: {
    Loading,
  },
  props: ["showLoading"],
  methods: {
    btnAddOnClick() {
      this.isHideParent = false;
    },
    rowOnClick(employee) {
      alert(employee.FullName);
    },
    closePopup(value) {
      this.isHideParent = value;
    },
    cancelLoading() {
      return false;
    },
  },

  data() {
    return {
      isLoading: false,
      canCancel: false,
      color: "#019160",
      loader: "dots", // bars  dots spinner
      onCancel: this.cancelLoading,
      width: 50,
      height: 50,
      backgroundColor: "#000",
      fullPage: false,
      opacity: 0.2,
      isHideParent: true,
      blur: "15px",
    };
  },
};
</script>
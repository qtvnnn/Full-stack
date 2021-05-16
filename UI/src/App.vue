<template>
  <div id="app">
    <div class="body-left">
      <NavBar />
    </div>
    <div class="body-right">
      <Header />
      <Content />
    </div>
  </div>
</template>

<script>

import NavBar from "@/components/layout/NavBar";
import Header from "@/components/layout/Header";
import Content from "@/components/layout/Content";

export default {
  name: "App",
  components: {
    NavBar,
    Header,
    Content,
  },
};
</script>



<style>
body {
  font-family: "MISA-Regular" !important;
  font-size: 13px !important;
  margin: 0px !important;
  padding: 0px !important;
  height: 100vh !important;
  background: #393a3d !important;
}

@font-face {
  font-family: "MISA-Regular";
  src: url("./assets/font/notosans-regular.2cb88a13.woff2") format("opentype");
}

@font-face {
  font-family: "MISA-Bold";
  src: url("./assets/font/notosans-bold.3ede5aff.woff2") format("opentype");
}

@font-face {
  font-family: "MISA-Italic";
  src: url("./assets/font/notosans-italic.1c1aaac9.woff2") format("opentype");
}

@font-face {
  font-family: "MISA-SemiBold";
  src: url("./assets/font/notosans-semibold.df3e6dc4.woff2") format("opentype");
}

::-webkit-scrollbar {
    width: 10px;
    height: 10px;
}

::-webkit-scrollbar-track {
  background: #f1f1f1;
}

::-webkit-scrollbar-thumb {
  background-color: #b8bcc3;
}
@import "~bootstrap/dist/css/bootstrap.css";
</style>

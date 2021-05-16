import Vue from 'vue'
import App from './App.vue'
import router from './router'
import './filter'
import './assets/css/layout.css'
import '../node_modules/jquery/dist/jquery.min.js'
import '../node_modules/bootstrap/dist/css/bootstrap.min.css'
import '../node_modules/bootstrap/dist/js/bootstrap.min.js'
import VueCurrencyInput from 'vue-currency-input'
import {
  library
} from '@fortawesome/fontawesome-svg-core'
import {
  faUserSecret,
  faTrash,
  faAngleRight,
  faAngleDoubleRight,
  faAngleDoubleLeft,
  faAngleLeft,
  faQuestionCircle
} from '@fortawesome/free-solid-svg-icons'
import {
  FontAwesomeIcon
} from '@fortawesome/vue-fontawesome'

library.add(faUserSecret, faTrash, faAngleRight, faAngleDoubleRight, faAngleDoubleLeft, faAngleLeft, faQuestionCircle)

Vue.component('font-awesome-icon', FontAwesomeIcon)

Vue.use(VueCurrencyInput)

Vue.config.productionTip = false

new Vue({
  router,
  render: h => h(App),
}).$mount('#app')
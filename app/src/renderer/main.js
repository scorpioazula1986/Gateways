import 'core-js/stable'
import Vue from 'vue'
import axios from 'axios'

import App from './App'
import router from './router'
import store from './store'
import CoreuiVue from '@coreui/vue'
import { iconsSet as icons } from './assets/icons/icons.js'

import 'devextreme/dist/css/dx.common.css'
import 'devextreme/dist/css/dx.material.blue.light.css'
import VueAlertify from 'vue-alertify'

Vue.config.performance = true
Vue.use(CoreuiVue)
Vue.use(VueAlertify)

if (!process.env.IS_WEB) Vue.use(require('vue-electron'))
Vue.http = Vue.prototype.$http = axios
Vue.config.productionTip = false

/* eslint-disable no-new */
new Vue({
  components: { App },
  router,
  icons,
  store,
  template: '<App/>'
}).$mount('#app')

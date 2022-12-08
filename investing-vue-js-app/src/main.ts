import { createApp } from 'vue'
import Antd from 'ant-design-vue'
import VueApexCharts from 'vue3-apexcharts'
import { FontAwesomeIcon } from '@fortawesome/vue-fontawesome'
import App from './App.vue'
import router from './router'
import store from './store'

import 'ant-design-vue/dist/antd.css'

createApp(App).use(store).use(router).use(Antd).use(VueApexCharts).component('font-awesome-icon', FontAwesomeIcon).mount('#app')

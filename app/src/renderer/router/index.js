import Vue from 'vue'
import Router from 'vue-router'
const TheContainer = () => import('@/containers/TheContainer')
const DashboardPage = () => import('@/views/DashboardPage')
const GatewaysPage = () => import('@/views/GatewaysPage')
const AddGatewayPage = () => import('@/views/AddGatewayPage')
const DetailsGatewayPage = () => import('@/views/DetailsGatewayPage')
const DevicesPage = () => import('@/views/DevicesPage')
const AddDevicePage = () => import('@/views/AddDevicePage')

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      component: TheContainer,
      children: [
        {
          path: 'dashboard',
          name: 'Dashboard',
          component: DashboardPage
        }, {
          path: 'gateways',
          name: 'Gateways',
          component: GatewaysPage
        }, {
          path: 'addgateway',
          name: 'Add New Gateway',
          component: AddGatewayPage
        }, {
          path: 'details/:id',
          name: 'Details',
          component: DetailsGatewayPage,
          props: true
        }, {
          path: 'gateways/devices/:id',
          name: 'Device List',
          component: DevicesPage,
          props: true
        }, {
          path: 'add/devices/:id',
          name: 'Add Device',
          component: AddDevicePage,
          props: true
        }
      ]
    }
  ]
})

<template>
<CCard>
    
    <CCardBody>
      <GatewayToolBar/>
       <dx-data-grid
        id="grid"
        @initialized="saveGridInstance"

        :show-borders="true"
        :column-auto-width="true"
        :row-alternation-enabled="true"
        :show-row-lines="true"
        :show-column-lines="true"
        :data-source="gateways"
        :hover-state-enabled="true"

        

       >
       <dx-column
          data-field="Id"
          :visible="false"
       />
      <dx-column data-field="serialNumber" caption="Serial Number"/>
      <dx-column data-field="name" caption="Name" />

      <dx-column data-field="ipv4" caption="Ipv4"/>
    <dx-column
        :width="110"
        :buttons="editButtons"
        type="buttons"
      />
      <dx-paging :page-size="5"/>
      <dx-pager
        :show-page-size-selector="true"
        :allowed-page-sizes="[5,10,15]"
        :show-info="true"
      />
      </dx-data-grid>
      
      
    </CCardBody>
  </CCard>
    
</template>
<script>
import axios from 'axios'
import {
  DxDataGrid,
  DxColumn,
  DxEditing,
  DxScrolling,
  DxSummary,
  DxLookup,
  DxTotalItem,
  DxPaging,
  DxPager
} from 'devextreme-vue/data-grid'
import { DxButton } from 'devextreme-vue/button'
import { DxSelectBox } from 'devextreme-vue/select-box'
import GatewayToolBar from './GatewayToolBar'

export default {
  props: {
    items: Array,
    url: String,
    gasto: Boolean
  },
  components: {
    DxDataGrid,
    DxColumn,
    DxEditing,
    DxScrolling,
    DxSummary,
    DxLookup,
    DxTotalItem,
    DxButton,
    DxSelectBox,
    DxPaging,
    GatewayToolBar,
    DxPager
  },
  data () {
    return {
      gridInstance: null,
      detailsModal: false,
      gateways: null,
      editButtons: [
        {
          hint: 'See Details',
          icon: 'check',
          onClick: function (e) {
            window.location.href = '#/details/' + e.row.data.id
          }
        }, {
          hint: 'See Devices',
          icon: 'menu',
          onClick: function (e) {
            window.location.href = '#/gateways/devices/' + e.row.data.id
          }
        }]
    }
  },
  mounted: function () {
    this.getDatos()
  },
  methods: {
    saveGridInstance: function (e) {
      this.gridInstance = e.component
    },
    getDatos: function () {
      axios.get('https://localhost:5001/api/gateways')
        .then(res => {
          this.gateways = res.data.data
          console.log(res.data.data)
        })
        .catch(e => {
          console.log(e)
        })
    },
    showModal: function (e) {
      this.detailsModal = true
      sessionStorage.setItem('idGateway', e.row.data.id)
    }
  }
}
</script>
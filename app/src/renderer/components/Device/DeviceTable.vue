<template>
<CCard>
    
    <CCardBody>
      <DeviceToolBar v-bind:id="id"/>
       <dx-data-grid
        id="grid"
        @initialized="saveGridInstance"

        :show-borders="true"
        :column-auto-width="true"
        :row-alternation-enabled="true"
        :show-row-lines="true"
        :show-column-lines="true"
        :data-source="devices"
        :hover-state-enabled="true"

        

       >
       <dx-column
          data-field="id"
          :visible="false"
       />
      <dx-column data-field="uid" caption="Uid"/>
      <dx-column data-field="vendor" caption="Vendor" />

      <dx-column data-field="status" caption="Status"/>
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
import DeviceToolBar from './DeviceToolBar'

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
export default {
  props: {
    id: {type: String, required: true, default: '0'}
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
    DeviceToolBar,
    DxPaging,
    DxPager
  },
  data () {
    return {
      gridInstance: null,
      devices: null,
      editButtons: [
        {
          hint: 'Delete',
          icon: 'trash',
          onClick: this.deleteDevice
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
      let identifier = Number.parseInt(this.id)
      axios.get('https://localhost:5001/api/gateways/' + identifier + '/devices')
        .then(res => {
          this.devices = res.data.data
          console.log(res.data.data)
        })
        .catch(e => {
          console.log(e)
        })
    },
    deleteDevice: function (e) {
      console.log(e)
      axios.delete('https://localhost:5001/api/devices/' + e.row.data.id)
        .then(res => {
          this.getDatos()
        })
        .catch(e => {
          console.log(e)
        })
    }
  }
}
</script>
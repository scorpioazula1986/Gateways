<template>
    <form class="pt-3"  @submit="handleSubmit">
        <dx-form
            :read-only="false"
            :show-colon-after-label="true"
            :show-validation-summary="true"
            :col-count="1"
            validation-group="customerData"
            @initialized="saveFormInstance"
        >
        <dx-simple-item data-field="uid">
        </dx-simple-item>
        <dx-simple-item data-field="vendor">
        </dx-simple-item>
        <dx-simple-item data-field="status" editor-type="dxSelectBox" :editorOptions="estadoOptions">>
        </dx-simple-item>
        
        <dx-button-item
            :button-options="buttonOptions"
            horizontal-alignment="left"
        />
            
        </dx-form>
         <dx-load-panel
            :visible.sync="loadingVisible"
            :show-indicator="showIndicator"
            :show-pane="showPane"
            :shading="shading"
            :close-on-outside-click="closeOnOutsideClick"
            shading-color="rgba(0,0,0,0.4)"
          />
    </form>
    
</template>
<script>
import axios from 'axios'
import notify from 'devextreme/ui/notify'
import DxForm, {
  DxSimpleItem,
  DxLabel,
  DxRequiredRule,
  DxButtonItem
} from 'devextreme-vue/form'
import { DxLoadPanel } from 'devextreme-vue/load-panel'
export default {
  components: {
    DxSimpleItem,
    DxLabel,
    DxRequiredRule,
    DxForm,
    DxLoadPanel,
    DxButtonItem,
    notify
  },
  props: {
    id: {type: String, required: true, default: '0'}
  },
  mounted () {
  },
  data () {
    return {
      loadingVisible: false,
      showIndicator: true,
      shading: true,
      showPane: true,
      closeOnOutsideClick: false,
      formInstance: null,
      estadoOptions: {
        displayExpr: 'text',
        valueExpr: 'id',
        items: [
          {
            id: 1,
            text: 'Online'
          },
          {
            id: 0,
            text: 'Offline'
          }
        ]
      },
      buttonOptions: {
        text: 'Save',
        icon: 'save',
        type: 'default',
        useSubmitBehavior: true
      },
      ipOptions: {
        mask: '000.000.000.000',
        useMaskedValue: true
      }
    }
  },
  methods: {
    saveFormInstance: function (e) {
      this.formInstance = e.component
    },
    addGateways: function () {
      let data = this.formInstance.option('formData')
      data.idGateway = Number.parseInt(this.id)
      let request = {
        device: data
      }
      axios.post('https://localhost:5001/api/devices', request)
        .then(res => {
          this.loadingVisible = false
          this.formInstance.resetValues()
        })
        .catch(e => {
          this.loadingVisible = false
          this.formInstance.resetValues()
          console.log(e)
        })
    },
    handleSubmit (e) {
      this.loadingVisible = true
      this.addGateways()
      e.preventDefault()
    }
  }
}
</script>
<template>
    <form class="pt-3"  @submit="handleSubmit">
        <dx-form
            :read-only="false"
            :form-data.sync="gateways"
            :show-colon-after-label="true"
            :show-validation-summary="true"
            :col-count="1"
            validation-group="customerData"
            @initialized="saveFormInstance"
        >
        <dx-simple-item data-field="serialNumber">
        </dx-simple-item>
        <dx-simple-item data-field="name">
        </dx-simple-item>
        <dx-simple-item data-field="ipv4" :editorOptions="ipOptions">
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
      gateways: null,
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
      let request = {
        gateway: data
      }
      axios.post('https://localhost:5001/api/gateways', request)
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
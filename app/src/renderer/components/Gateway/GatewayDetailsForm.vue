<template>
    <form class="pt-3">
        <dx-form
            :read-only="true"
            :form-data.sync="gateway"
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
        <dx-simple-item data-field="devices">
        </dx-simple-item>
            
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
import notify from 'devextreme/ui/notify'
import axios from 'axios'
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
    this.getGateway()
  },
  data () {
    return {
      loadingVisible: false,
      showIndicator: true,
      shading: true,
      showPane: true,
      closeOnOutsideClick: false,
      formInstance: null,
      gateway: null,
      buttonOptions: {
        text: 'Save',
        icon: 'save',
        type: 'default',
        useSubmitBehavior: true
      },
      ipOptions: {
        mask: '000.000.000.000'
      }
    }
  },
  methods: {
    saveFormInstance: function (e) {
      this.formInstance = e.component
    },
    getGateway: function () {
      let identifier = Number.parseInt(this.id)
      axios.get('https://localhost:5001/api/gateways/' + identifier)
        .then(res => {
          this.gateway = res.data.data
        })
        .catch(e => {
          console.log(e)
        })
    }
  }
}
</script>
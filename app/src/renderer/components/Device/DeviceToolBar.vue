<template>
    <dx-toolbar>
      <dx-item
        :options="addButtonOptions"
        location="before"
        widget="dxButton"
      />
     
       
     
     
      
    </dx-toolbar>
</template>
<script>
import DxToolbar, { DxItem } from 'devextreme-vue/toolbar'
export default {
  components: {
    DxToolbar,
    DxItem
  },
  props: {
    id: {type: String, required: true, default: '0'}
  },
  data () {
    return {
      estadoSelectBox: null,
      addButtonOptions: {
        icon: 'plus',
        hint: 'Add Device',
        onClick: this.addDevice
      }
    }
  },
  methods: {
    addDevice: function () {
      this.$router.push('/add/devices/' + this.id)
    }
  }
}
</script>

<style scoped
.toolbar-label,
.toolbar-label > b {
    font-size: 16px;
}
</style>
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
  name: 'IngresosToolBar',
  components: {
    DxToolbar,
    DxItem
  },
  data () {
    return {
      estadoSelectBox: null,
      addButtonOptions: {
        icon: 'plus',
        hint: 'Add Gateway',
        onClick: () => {
          this.$router.push('/addgateway')
        }
      },
      buscarButtonOptions: {
        icon: 'search',
        hint: 'Buscar'
      }
    }
  },
  methods: {
  }
}
</script>

<style scoped>
.toolbar-label,
.toolbar-label > b {
    font-size: 16px;
}
</style>
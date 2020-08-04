<template>
<div>
    <CRow>
        <CCol xs="12" lg="12">
            <CCard>
                <CCardHeader>
                    Device List
                </CCardHeader>
                <CCardBody>
                    <DeviceTable v-bind:id="id"/>

                </CCardBody>
            </CCard>
        </CCol>

    </CRow>
</div>
    
</template>
<script>
import DeviceTable from '../components/Device/DeviceTable'
export default {
  components: {
    DeviceTable
  },
  props: {
    id: {type: String, required: true, default: '0'}
  }
}
</script>
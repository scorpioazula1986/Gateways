<template>
<div>
    <CRow>
        <CCol xs="12" lg="12">
            <CCard>
                <CCardHeader>
                    Add Device
                </CCardHeader>
                <CCardBody>

                    <AddDeviceForm v-bind:id="id"></AddDeviceForm>

                </CCardBody>
            </CCard>
        </CCol>

    </CRow>
</div>
    
</template>
<script>
import AddDeviceForm from '../components/Device/AddDeviceForm'

export default {
  components: {
    AddDeviceForm
  },
  props: {
    id: {type: String, required: true, default: '0'}
  }
}
</script>
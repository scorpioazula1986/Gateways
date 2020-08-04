<template>
<div>
    <CRow>
        <CCol xs="12" lg="12">
            <CCard>
                <CCardHeader>
                    Gateway Details
                </CCardHeader>
                <CCardBody>
                    <GatewayDetailsForm v-bind:id="id"/>

                </CCardBody>
            </CCard>
        </CCol>

    </CRow>
</div>
    
</template>
<script>
import GatewayDetailsForm from '../components/Gateway/GatewayDetailsForm'
export default {
  components: {
    GatewayDetailsForm
  },
  props: {
    id: {type: String, required: true, default: '0'}
  }
}
</script>
<template>
<div>
    <CRow>
        <CCol xs="12" lg="12">
            <CCard>
                <CCardHeader>
                    Add Gateway
                </CCardHeader>
                <CCardBody>

                    <AddGatewayForm></AddGatewayForm>

                </CCardBody>
            </CCard>
        </CCol>

    </CRow>
</div>
    
</template>
<script>
import AddGatewayForm from '../components/Gateway/AddGatewayForm'

export default {
  components: {
    AddGatewayForm
  }
}
</script>
<template>
<div>
    <CRow>
        <CCol xs="12" lg="12">
            <CCard>
                <CCardHeader>
                    Gateways List
                </CCardHeader>
                <CCardBody>

                    <GatewayTable></GatewayTable>

                </CCardBody>
            </CCard>
        </CCol>

    </CRow>
</div>
    
</template>
<script>
import GatewayTable from '../components/Gateway/GatewayTable'

export default {
  components: {
    GatewayTable
  }
}
</script>
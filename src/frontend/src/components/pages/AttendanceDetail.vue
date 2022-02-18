<template>
  <v-container>
    <attendance-detail-top-area />
    <attendance-detail-table-area />
  </v-container>
</template>

<script>
import AttendanceDetailTopArea from "../organisms/attendancedetail/AttendanceDetailTopArea.vue";
import AttendanceDetailTableArea from "../organisms/attendancedetail/AttendanceDetailTableArea.vue";

export default {
  components: {
    AttendanceDetailTopArea,
    AttendanceDetailTableArea,
  },
};
</script>

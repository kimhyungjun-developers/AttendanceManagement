<template>
  <v-container>
    <v-row class="text-center attendanceHeaderRowTop">
      <v-col cols="12" sm="3">
        <v-col cols="12">
          <select-month />
        </v-col>
        <v-col cols="12">
          <default-work-time-form />
        </v-col>
      </v-col>
      <v-col cols="12" sm="5">
        <display-time />
      </v-col>
      <!-- TODO 未出勤/出勤済みの切り替え表示 -->
      <v-col col="12" sm="4" align-self="center">
        <v-col cols="12">
          <div class="text-left">
            <p v-show="false">未出勤</p>
            <p v-show="false">入力中</p>
          </div>
        </v-col>
        <v-col cols="12" />
        <v-col cols="12" class="d-flex justify-end align-end">
          <v-btn color="info">保存</v-btn>
        </v-col>
      </v-col>
    </v-row>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";
import SelectMonth from "@/plugins/materials/molecules/attendancedetail/selectAttendanceMonth.vue";
import DisplayTime from "@/plugins/materials/molecules/attendancedetail/displayTime.vue";
import DefaultWorkTimeForm from "@/plugins/materials/molecules/attendancedetail/selectDefaultWorkTime.vue";

export default Vue.extend({
  components: {
    SelectMonth,
    DisplayTime,
    DefaultWorkTimeForm,
  },
});
</script>

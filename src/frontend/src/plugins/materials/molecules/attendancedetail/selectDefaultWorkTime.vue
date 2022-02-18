<template>
  <v-form v-model="valid">
    <v-container>
      <v-col>
        <v-select
          item-text="label"
          item-value="value"
          :items="startWorkTime"
          label="所定開始時間"
          dense
          return-object
        >
        </v-select>

        <v-select
          item-text="label"
          item-value="value"
          :items="endWorkTime"
          label="所定終了時間"
          dense
          return-object
        >
        </v-select>
      </v-col>
    </v-container>
  </v-form>
</template>

<script>
import Vue from "vue";

export default Vue.extend({
  components: {},
  data: () => ({
    startWorkTime: [
      { label: "4:00", value: "4:00" },
      { label: "4:30", value: "4:30" },
      { label: "5:00", value: "5:00" },
      { label: "5:30", value: "5:30" },
      { label: "6:00", value: "6:00" },
      { label: "6:30", value: "6:30" },
      { label: "7:00", value: "7:00" },
      { label: "7:30", value: "7:30" },
      { label: "8:00", value: "8:00" },
      { label: "8:30", value: "8:30" },
      { label: "9:00", value: "9:00" },
      { label: "9:30", value: "9:30" },
      { label: "10:00", value: "10:00" },
      { label: "10:30", value: "10:30" },
      { label: "11:00", value: "11:00" },
      { label: "11:30", value: "11:30" },
      { label: "12:00", value: "12:00" },
      { label: "12:30", value: "12:30" },
      { label: "13:00", value: "13:00" },
      { label: "13:30", value: "13:30" },
      { label: "14:00", value: "14:00" },
      { label: "14:30", value: "14:30" },
    ],
    endWorkTime: [
      { label: "15:00", value: "15:00" },
      { label: "15:30", value: "15:30" },
      { label: "16:00", value: "16:00" },
      { label: "16:30", value: "16:30" },
      { label: "17:00", value: "17:00" },
      { label: "17:30", value: "17:30" },
      { label: "18:00", value: "18:00" },
      { label: "18:30", value: "18:30" },
      { label: "19:00", value: "19:00" },
      { label: "19:30", value: "19:30" },
      { label: "20:00", value: "20:00" },
      { label: "20:30", value: "20:30" },
      { label: "21:00", value: "21:00" },
      { label: "21:30", value: "21:30" },
      { label: "22:00", value: "22:00" },
      { label: "22:30", value: "22:30" },
      { label: "23:00", value: "23:00" },
      { label: "23:30", value: "23:30" },
      { label: "24:00", value: "24:00" },
    ],
  }),
});
</script>

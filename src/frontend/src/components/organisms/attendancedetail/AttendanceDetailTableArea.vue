<template>
  <v-container>
    <v-row>
      <!-- TODO 各列の表示幅 -->
      <!-- TODO 勤労状況の入力をリスト化 -->
      <v-col cols="12">
        <v-card>
          <v-data-table
            :headers="headers"
            :items="items"
            fixed-header
            height="400px"
            dense
            hide-default-footer
            disable-pagination
          >
          </v-data-table>
        </v-card>
      </v-col>
    </v-row>
  </v-container>
</template>

<script>
import Vue from "vue";

export default Vue.extend({
  components: {},
  data() {
    return {
      headers: [
        {
          text: "日",
          sortable: false,
          value: "date",
          class: "font-weight-bold blue",
        },
        {
          text: "曜日",
          sortable: false,
          value: "ofWeek",
          class: "font-weight-bold blue",
        },
        {
          text: "勤労状況",
          justify: "center",
          sortable: false,
          value: "workDivision",
          class: "font-weight-bold blue",
        },
        {
          text: "出勤時間",
          sortable: false,
          value: "startTime",
          class: "font-weight-bold blue",
        },
        {
          text: "退勤時間",
          sortable: false,
          value: "endTime",
          class: "font-weight-bold blue",
        },
        {
          text: "休憩時間",
          sortable: false,
          value: "restTime",
          class: "font-weight-bold blue",
        },
        {
          text: "労働時間",
          sortable: false,
          value: "workTime",
          class: "font-weight-bold blue",
        },
        {
          text: "深夜作業時間",
          sortable: false,
          value: "midnightTime",
          class: "font-weight-bold blue",
        },
        {
          text: "備考",
          sortable: false,
          value: "note",
          class: "font-weight-bold blue",
        },
      ],
      items: [
        {
          id: 1,
          date: 1,
          ofWeek: "月",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 2,
          date: 2,
          ofWeek: "火",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 3,
          date: 3,
          ofWeek: "水",
          workDivision: "有給",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "私用のため",
        },
        {
          id: 4,
          date: 4,
          ofWeek: "木",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 5,
          date: 5,
          ofWeek: "金",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 6,
          date: 6,
          ofWeek: "土",
          workDivision: "",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "",
        },
        {
          id: 7,
          date: 7,
          ofWeek: "日",
          workDivision: "",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "",
        },
        {
          id: 8,
          date: 8,
          ofWeek: "月",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 9,
          date: 9,
          ofWeek: "火",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 10,
          date: 10,
          ofWeek: "水",
          workDivision: "有給",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "私用のため",
        },
        {
          id: 11,
          date: 11,
          ofWeek: "木",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 12,
          date: 12,
          ofWeek: "金",
          workDivision: "出勤",
          startTime: "9:00",
          endTime: "18:00",
          restTime: "1:00",
          workTime: "8:00",
          midnightTime: "0:00",
          note: "",
        },
        {
          id: 13,
          date: 13,
          ofWeek: "土",
          workDivision: "",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "",
        },
        {
          id: 14,
          date: 14,
          ofWeek: "日",
          workDivision: "",
          startTime: "",
          endTime: "",
          restTime: "",
          workTime: "",
          midnightTime: "",
          note: "",
        },
      ],
    };
  },
});
</script>

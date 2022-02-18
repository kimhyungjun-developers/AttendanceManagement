import vuetify from "@/plugins/vuetify";
import TableArea from "../components/organisms/attendancedetail/AttendanceDetailTableArea.vue";

export default {
  title: "AttendanceDetail/TableArea",
  component: TableArea,
};

/* story記述 */
// default
// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
export const Default = () => ({
  // 変数名がナビゲーションパネルでの表示名となる
  components: { TableArea }, // 対象となるコンポーネントを指定する
  vuetify,
  template: "<table-area />", // レンダリングするhtmlを記述する
});

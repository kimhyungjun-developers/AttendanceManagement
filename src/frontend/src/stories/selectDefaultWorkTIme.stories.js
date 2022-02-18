import vuetify from "@/plugins/vuetify";
import DefaultWorkTime from "../plugins/materials/molecules/attendancedetail/selectDefaultWorkTime";

export default {
  title: "AttendanceDetail/selectDefaultWorkTime",
  component: DefaultWorkTime,
};

/* story記述 */
// default
export const Default = () => ({
  // 変数名がナビゲーションパネルでの表示名となる
  components: { DefaultWorkTime }, // 対象となるコンポーネントを指定する
  vuetify,
  template: "<default-work-time />", // レンダリングするhtmlを記述する
});

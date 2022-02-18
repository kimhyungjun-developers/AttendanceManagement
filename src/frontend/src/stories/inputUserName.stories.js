import vuetify from "@/plugins/vuetify";
import InputUserName from "../plugins/materials/molecules/attendancedetail/inputUserName";

export default {
  title: "AttendanceDetail/inputUserName",
  component: InputUserName,
};

/* story記述 */
// default
export const Default = () => ({
  // 変数名がナビゲーションパネルでの表示名となる
  components: { InputUserName }, // 対象となるコンポーネントを指定する
  vuetify,
  template: "<input-user-name />", // レンダリングするhtmlを記述する
});

import vuetify from "@/plugins/vuetify";
import TopArea from "../components/organisms/attendancedetail/AttendanceDetailTopArea.vue";

export default {
  title: "AttendanceDetail/TopArea",
  component: TopArea,
};

/* story記述 */
// default
// eslint-disable-next-line @typescript-eslint/explicit-module-boundary-types
export const Default = () => ({
  // 変数名がナビゲーションパネルでの表示名となる
  components: { TopArea }, // 対象となるコンポーネントを指定する
  vuetify,
  template: "<top-area />", // レンダリングするhtmlを記述する
});

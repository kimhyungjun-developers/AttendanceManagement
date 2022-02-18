import vuetify from "@/plugins/vuetify";
import SideNavigationArea from "../components/common/sidearea/SideNavigationArea.vue";

export default {
  title: "AttendanceDetail/SideNavigationArea",
  component: SideNavigationArea,
};

/* story記述 */
// default
export const Default = () => ({
  // 変数名がナビゲーションパネルでの表示名となる
  components: { SideNavigationArea }, // 対象となるコンポーネントを指定する
  vuetify,
  template: "<side-navigation-area />", // レンダリングするhtmlを記述する
});

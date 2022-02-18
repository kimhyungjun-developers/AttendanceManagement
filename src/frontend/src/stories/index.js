import Vue from "vue";
import { storiesOf } from "@storybook/vue";

import MyButton from "../components/organisms/attendancedetail/AttendanceDetailTopArea.vue";
Vue.component("MyButton", MyButton);

storiesOf("MyButton", module).add("simple", () => ({
  components: { MyButton },
  template: `<MyButton>KEEP IT SIMPLE</MyButton>`,
}));

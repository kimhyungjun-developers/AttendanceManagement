<template>
  <v-container>
    <v-select
      item-text="label"
      item-value="value"
      :items="month"
      label="年月"
      dense
      outlined
      return-object
    >
    </v-select>
  </v-container>
</template>

// TODO Modelとの紐付け
<script>
import Vue from "vue";

export default Vue.extend({
  components: {},
  data: () => ({
    month: [
      { label: "2021年4月", value: "1" },
      { label: "2021年5月", value: "2" },
    ],
  }),
});
</script>

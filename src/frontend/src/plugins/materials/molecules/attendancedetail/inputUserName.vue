<template>
  <v-form v-model="valid">
    <v-container>
      <v-col>
        <v-text-field
          v-model="userName"
          :rules="userNameRule"
          label="氏名"
          required
          hide-details="auto"
          counter="13"
          maxlength="13"
        ></v-text-field>
      </v-col>
    </v-container>
  </v-form>
</template>

<script>
import Vue from "vue";

export default Vue.extend({
  components: {},
  data: () => ({
    valid: false,
    userName: "",
    userNameRule: [
      (v) => !!v || "氏名を入力してください。",
      (v) => v.length <= 13 || "氏名は13文字以内にしてください。",
    ],
  }),
});
</script>

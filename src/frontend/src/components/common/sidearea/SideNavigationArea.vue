<template>
  <v-card height="100%" width="256px" class="mx-auto">
    <v-navigation-drawer permanent>
      <v-list-item>
        <v-list-item-content>
          <v-img src="../../../assets/logo.png"></v-img>
        </v-list-item-content>
      </v-list-item>
      <v-divider></v-divider>

      <v-list nav shaped>
        <v-list-item
          v-for="item in navigationList"
          :key="item.title"
          :to="item.url"
          color="primary"
          class="navigationList"
        >
          <v-list-item-icon>
            <v-icon>{{ item.icon }}</v-icon>
          </v-list-item-icon>

          <v-list-item-content class="navigationTitle">
            <v-list-item-title>{{ item.title }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-divider></v-divider>

        <v-list-item>
          <v-list-item-icon>
            <v-icon>mdi-account</v-icon>
          </v-list-item-icon>
          <v-list-item-content>
            <v-list-item-title>ID: {{ this.userId }}</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item link class="logoutBtn">
          <v-list-item-icon>
            <v-icon>mdi-logout-variant</v-icon>
          </v-list-item-icon>

          <v-list-item-content>
            <v-list-item-title @click="onLogoutBtn()"
              >ログアウト</v-list-item-title
            >
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>
  </v-card>
</template>

<script>
import Vue from "vue";

export default Vue.extend({
  data() {
    return {
      /*
       * サイドメニュー項目定義
       * @type {array[object]}
       */
      navigationList: [
        /*
         * ナビゲーション表示項目(ログインユーザーの権限種別で表示する項目を制御)
         * @type {string]} - title ナビゲーション項目名
         * @type {string]} - icon アイコン種別
         * @type {string]} - dispRights 表示権限種別
         * @type {string]} - url 遷移先のパス
         */
        {
          title: "勤務表を入力する",
          icon: "mdi-calendar-month-outline",
          dispRights: "",
          url: "/",
        },
        {
          title: "ユーザー設定をする",
          icon: "mdi-account-cog",
          dispRights: "",
          url: "/user_config",
        },
        {
          title: "勤務表一覧を見る",
          icon: "mdi-calendar-multiple",
          dispRights: "authorizer",
          url: "/attendance_list",
        },
        {
          title: "ユーザーを管理する",
          icon: "mdi-account-multiple",
          dispRights: "administrator",
          url: "/user_management",
        },
        {
          title: "休日設定を管理する",
          icon: "mdi-calendar-weekend",
          dispRights: "administrator",
          url: "/holiday",
        },
      ],

      /*
       * ログインユーザーの閲覧権限
       * @type {string}
       */
      userDispRights: 1,
      // TODO ↑ダミーデータです。APIからデータ取れるようになったら要修正（1:一般ユーザー,2:グループリーダー,3:管理者、を想定しています）

      /*
       * ログインユーザーID
       * @type {string}
       */
      userId: "Try102938",
      // TODO ↑ダミーデータです。APIからデータ取れるようになったら要修正
    };
  },
  methods: {
    /*
     * ログインしているユーザーの管理者権限を確認してナビゲーション表示用の連想配列を生成
     * @return {void}
     */
    dispNavigationList() {
      switch (this.userDispRights) {
        case 1:
          this.navigationList = this.navigationList.filter(function (e) {
            return (
              e.dispRights !== "authorizer" && e.dispRights !== "administrator"
            );
          });
          break;

        case 2:
          this.navigationList = this.navigationList.filter(function (e) {
            return e.dispRights !== "administrator";
          });
          break;
      }
    },

    /*
     * TODO ログアウトする
     * @return {void}
     */
    onLogoutBtn() {
      alert("TODO ログアウト処理を実装します");
    },
  },
  mounted() {
    this.dispNavigationList();
  },
});
</script>

<style scoped>
/* TODO ID・ログアウトエリアをサイドバーしたに固定するスタイルを追加(親コンポネートの縦サイズが決まらないと実装できないため後々) */
/* TODO スマホ・タブレット対応 */
.navigationList {
  transition: 0.4s;
}
.navigationList:hover {
  background-color: rgba(25, 118, 210, 0.1);
}
.navigationTitle {
  transition: 0.4s;
}
.navigationTitle:hover {
  padding-left: 5px;
}
.logoutBtn {
  transition: 0.4s;
}
.logoutBtn:hover {
  background-color: rgba(255, 0, 0, 0.3);
}
</style>

<template>
  <v-container>
    <div id="today">
      <p id="todayDate"></p>
    </div>
    <div id="now">
      <p id="nowTime" class="text-h2"></p>
    </div>
    <div class="attendanceBtn mt-8">
      <v-btn color="success" class="mr-8">出勤</v-btn>
      <v-btn color="error">退勤</v-btn>
    </div>
  </v-container>
</template>

<script>
export default {
  components: {},
  methods: {
    getTime() {
      //HTTPリクエストヘッダーよりサーバー時刻を取得し1秒ごとに実行・代入を行う
      setInterval(
        function () {
          let request = new XMLHttpRequest();
          request.open("HEAD", window.location.href, true);
          request.send();
          request.onreadystatechange = function () {
            if (this.readyState === 4) {
              let serverDate = new Date(request.getResponseHeader("Date"));
              let serveYear = serverDate.getFullYear();
              let serveMonth = serverDate.getMonth() + 1;
              let serveDate = serverDate.getDate();
              let date = ["日", "月", "火", "水", "木", "金", "土"];
              let serveDay = date[serverDate.getDay()]; //曜日は数値で返ってくるため配列で漢字に変更
              let today =
                serveYear +
                "年" +
                serveMonth +
                "月" +
                serveDate +
                "日" +
                "(" +
                serveDay +
                ")";
              let targetDate = document.getElementById("todayDate");
              targetDate.innerText = today;

              let servehours = serverDate.getHours();
              let serveMinutes = serverDate.getMinutes();

              if (servehours < 10) {
                //時・分が1桁の時先頭に0をつけて表示を2桁に固定
                servehours = "0" + servehours;
              }
              if (serveMinutes < 10) {
                serveMinutes = "0" + serveMinutes;
              }

              let now = servehours + ":" + serveMinutes;

              let targetNowTime = document.getElementById("nowTime");
              targetNowTime.innerText = now;
            }
          };
        }.bind(this),
        1000
      );
    },
  },
  created: function () {
    this.getTime();
  },
};
</script>

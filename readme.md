# 勤務表 Web 管理システム

## 要件定義書

[要件定義書](https://growi.tangle.tokyo/%E8%A8%AD%E8%A8%88%E8%B3%87%E6%96%99/%E8%A6%81%E4%BB%B6%E5%AE%9A%E7%BE%A9%E6%9B%B8/%E5%8B%A4%E5%8B%99%E8%A1%A8Web%E5%8C%96)

## 技術仕様

| 項目           | 選定                                     |
| -------------- | ---------------------------------------- |
| フロントエンド | TypeScript + webpack + Vue.js            |
| バックエンド   | C# + ASP.NetCore + Entity Framework Core |
| データベース   | SQLServer                                |

## 開発環境におけるデータベース構築

ローカル PC に Docker がインストールされている状態で、下記コマンドを実行することで DB の構築が可能

```cmd
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=P@ssw0rd!' -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
```

※一部Windows環境では二重引用符にする必要有
```cmd
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=P@ssw0rd!" -p 1433:1433 mcr.microsoft.com/mssql/server:2019-latest
```

## データベースのマイグレーションについて

cmd フォルダ内にある `migration.cmd` ファイルをダブルクリックすることで、マイグレーション支援ツールを起動可能

## 検証用アカウント（リリースまで）
- 管理者アカウント
  - メールアドレス : `admin@example.com`
  - パスワード : `P@ssw0rd!`
- 一般アカウント
  - メールアドレス : `general@example.com` 
  - パスワード : `P@ssw0rd!`
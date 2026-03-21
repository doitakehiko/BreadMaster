# BreadMaster

## 概要
BreadMasterはサンドイッチのフィリング、ソース、パン名、地域名を管理するためのアプリケーションです。Oracleデータベースを使用して、サンドイッチの情報を保存し、管理します。

## 技術スタック
- プログラミング言語: c#
- [.NETFramework,Version=v4.8.1]
- [C# 12]

## 構築・実行手順
AppConstants.cs を追加する必要がある
AppConstants.cs の内容は以下の通りです。


```C#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
namespace BreadMaster
{
    public static class BreadMasterAppConstants
    {
        public const string connectionString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=youroraclehost)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=yourCONTAINER)));User Id=yourusername;Password=yourpassword;";
        public const string sCrLf = "\r\n";
        public static int getUniqMasterId(OracleConnection connection, string sql, string name )
        {
            try
            {
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    command.Parameters.Add(new OracleParameter("name", name));

                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return int.Parse(reader["id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラー: {ex.Message}");
            }
            return 0;
        }
        public static int getCurrentSequenceValue(OracleConnection connection, string sql)
        {
            try
            {
                using (OracleCommand command = new OracleCommand(sql, connection))
                {
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            return int.Parse(reader["id"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"エラー: {ex.Message}");
            }
            return 0;
        }
    }
}
```





  - connectionString の値を、実際のOracleデータベースの接続情報に置き換えてください。


  ## データベース構造
  SqlQueries以下のテーブルを必要とする


  テーブル仕様は以下リンクを参照してください。

  https://docs.google.com/spreadsheets/d/1lou3vT2Q1-e9iwCM1pCaya94zIDec8buK7mHt0aWlbA/edit?usp=sharing

  ## 事前準備
  0. Oracle Database 19c Enterprise Edition Releaseをセットアップする
  1. checkconfig.sql を sqlplus で実行して、権限を確認してください。NGが出る場合は2.に進んでください。
  2. setup_user.sql を sqlplus でsysdba権限で実行して、ユーザー作成と権限付与を行ってください。
  
  ##  インストール方法
  1. Oracle Data Access Components (ODAC) をインストールします。
  2. sqlclient をインストールします。
       - NuGet パッケージマネージャーを使用して、Oracle.DataAccess.Client をプロジェクトに追加します。
  3. sqlplus で install.sql を実行して、必要なテーブルとシーケンスを作成します。 

  ## アンインストール方法
  1. sqlplus で uninstall.sql を実行して、作成したテーブルとシーケンスを削除します。

  
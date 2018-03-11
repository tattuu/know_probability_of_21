## システム内容

+ ブラックジャックの出現確立が分かるブラックジャック

## 実行手順

1. WindowsApplication1をクリック
2. WindowsApplication1をクリック
3. binをクリック
4. Debugをクリック
5. WindowsApplication1.exeをクリック

## 遊び方

+ STANDボタンかHITボタンかを選択して遊ぶ(ルールは通常のブラックジャックと同 じ)
+ ブラックジャックの確立が見たい場合は、閉じるボタン(×ボタン)をクリックする

## 注意事項

+ 5枚までしか表示できない状態になっているので、
片方が6枚以上カードを引かなければならない場合は、6枚目以降が無視される状態になっている。
なので、その場合はその回の結果を無効とし、再度ゲームをやり直していただきたい。

## 自分がプログラミングして作成したファイルの構成(WindowsApplication1フォルダ内)

### Childform.vb

+ ルール説明をしているウィンドウに関するファイル

### Main.vb

+ ゲームを行うメイン画面に関するファイル

### Store.vb

+ 全ページにまたがる共通の値が消えないように保持する事に関するファイル

### Top.vb

+ Top画面に関するファイル

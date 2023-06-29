# AvaloniaMarkdown
[![license](https://img.shields.io/badge/license-MIT-green.svg)](./LICENSE)

Avalonia UI开发的Markdown的文本编辑器，主要用于学习和实践。
## 1.界面功能设计

* 左边输入框，使用TextBox
* 右边添加Markdown.Avalonia控件
* 打开文件按钮-打开文件，提取文件内容
* 保存-如果是新文件，选择保存路径-如果是已打开的文件，保存现有文件。
## 2.编辑框和Markdown展示代码

```c#
<TextBox Grid.Row="1"
    Grid.Column="0"
    VerticalAlignment="Stretch"
    AcceptsReturn="True"
    Text="{Binding Text}"
    TextWrapping="Wrap"
    />
    <md:MarkdownScrollViewer Grid.Row="1"
        Grid.Column="1" Name="abc" Markdown="{Binding Text}"/>
```
## 3.成果

![image-20230629223736054](https://www.raokun.top/upload/2023/06/image-20230629223736054.png)

## 4.总结
  对应的开发总结我已经写在了我的博客中，可前往查看：[https://www.raokun.top](https://www.raokun.top)

  

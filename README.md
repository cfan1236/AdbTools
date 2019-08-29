# AdbTools


Adb工具


----------
由于工作原因有时候需要对公司的app进行截图、快速安装apk、监控日志等。尤其是公司测试同事，经常需要用到截图和安装最新安装包。

随即就想能不能基于adb写个图形化的工具，不用每次都去使用命令来完成。尤其类似于截图可以直接复制到剪切板，方便随处粘贴。其实像目前市面上各种电脑安装的手机助手也都是基于adb去完成的。只是这些软件都太
庞大并且广告多还喜欢给你偷偷安装其他各种软件等。

工具开发起来很简单，在.Net里面使用Process类来执行CMD命令即可。

需要注意的是在使用adb命令的时候经常需要针对结果进行过滤，比如linux里面grep,windows是使用findstr。如果是进入了adb shell里面后执行的命令都是linux命令了。


### 运行截图

![图1](https://github.com/cfan1236/AdbTools/blob/master/img/20190820165055.png)

![图2](https://github.com/cfan1236/AdbTools/blob/master/img/20190820165232.png)


启动方式：一是直接指定配置参数，二是指定配置文件
# ./mongod --config /etc/mongodb.conf

进入bin目录：
启动服务，--fork后台运行 ,
# ./mongod --dbpath=../data/db --logpath=../data/logs/mongodb.log --logappend --fork
以autho方式启动：
# ./mongod --dbpath=../data/db --logpath=../data/logs/mongodb.log --logappend --fork --auth


检查端口是否启动：
netstat -lanp  | grep 37011

设置用户名：
> usadmin
> db.addUser("name","pwd");   -----V3版本以不再使用
> db.createUser(
   {
     user: "huoqishi",
     pwd: "pwd!=kkisc",
     roles: [ {role:"root", db:"test"} ]
   },
   {w: "majority" , wtimeout: 5000}
)
db.createUser(
   {
     user: "htest",
     pwd: "pwd_sc",
     roles: [ {role:"readWrite", db:"test"} ]
   },
   {w: "majority" , wtimeout: 10000}
)

配置:
dbpath=/usr/local/mongodb/data/db
logpath=/usr/local/mongodb/data/logs/mongodb.log
port=37011
fork=true
nohttpinterface=false
logappend=true


//指定用户名和密码连接到指定的MongoDB数据库
//////连接/////
./mongo 192.168.1.200:27017/test -u huoqishi -p pwd!=kkisc
./mongo locahost:37011/test -u huoqishi -p pwd!=kkisc

关闭服务中：
db.shutdownServer({force : true})；
mongod  --shutdown  --dbpath /database/mongodb/data/

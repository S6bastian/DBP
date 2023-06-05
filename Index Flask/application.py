import datetime
import random
from flask import Flask, render_template, request


app = Flask(__name__)

@app.route("/")
def index():
    return render_template("index.html")

#conditions
@app.route("/new_year")
def new_year():
    now = datetime.datetime.now()
    new_year = now.month == 1 and now.day == 1
    return render_template("conditions/new_year.html", new_year=new_year)

#first
@app.route("/hello_world")
def hello_world():
    return "Hello, world!"

#forms
@app.route("/hello", methods=["POST"])
def hello():
    name = request.form.get("name")
    return render_template("forms/hello.html", name=name)

#inheritance
@app.route("/more")
def more():
    return render_template("inheritance/more.html")
@app.route("/index_in")
def index_in():
    return render_template("inheritance/index_in.html")

#loops
@app.route("/loops")
def loops():
    names = ["Alice", "Bob", "Charlie"]
    return render_template("loops/index.html", names=names)

#routes0
@app.route("/david")
def david():
    return "Hello, David!"

#routes1
#no se muestra en index
@app.route("/<string:name>")
def hello1(name):
    return "Hello, {}!".format(name)

#static
@app.route("/static1")
def index_static1():
    return render_template("static/index.html")
@app.route("/static2")
def more_static2():
    return render_template("static/more.html")

#templates
@app.route("/templatess")
def templatess():
    return render_template("templatess/index.html")

#urls
@app.route("/index_urls")
def index_urls():
    return render_template("urls/index.html")
@app.route("/more_urls")
def more_urls():
    return render_template("urls/more.html")

#variables0
@app.route("/variables0")
def index_variables0():
    headline = "BLABLABLA!"
    return render_template("variables0/index.html", headline=headline)

#variables1
@app.route("/variables1")
def index_variables1():
    headline = random.choice(["Hello, world!", "Hi there!", "Good morning!"])
    return render_template("variables1/index.html", headline=headline)


if __name__ == '__main__':
    app.run(debug=True)
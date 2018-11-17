class Student{
    constructor (homework=[]){
        this.homework = homework;
    }

    study (){
        console.log(this.homework);
    }
}

const st = new Student([
    'blog',
    'api',
    'vue'
]);

st.study();
let array = [ 5,5423,4,2,523,5,235,235,23,523,5]
let h=0
a=array.length

for(let i=0; i<a; i++){
    h=0
    for(let b=0;b<a;b++){
        if(array[i]==array[b]){
            h++
        }
    }
    if(h==1){
        console.log(array[i])
    }
}

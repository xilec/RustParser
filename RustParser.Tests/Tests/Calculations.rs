fn main() {
    let a = calc();
}

fn calc() -> usize {
    let c: usize = 7;
    let a=3;
    let b:usize=5;
    let d=11us;
    let res = a + b * (d - c) / 3;
    let mut res1: usize = a + b * (d - c) / 3;
    res1 = a + b * (d - c) / 3;
    res
}
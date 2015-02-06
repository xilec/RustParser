fn main() {
    for item in 0..10 {}
    for item in 0 .. 10 {};
    for item in 0..10 {println!("Foo")}
    for item in 0..10 {println!("Foo")};
    for item in 0..10 {println!("Foo");}
    for item in 0..10 {println!("Foo");};
    for item in 0..10 {break; continue; break};
}
//
//  AppController.m
//  Unity-iPhone
//
//  Created by Kyle on 2/13/20.
//

#import "AppController.h"``

extern void UnitySendMessage(const char* obj, const char* method, const char* msg);

@implementation AppController {
    UIButton *btn;
}

- (void)startUnity:(UIApplication *)application {
    [super startUnity:application];
    
    UIViewController *vc = [UIViewController new];
    
    [vc.view setFrame:self.window.bounds];
    [vc.view addSubview:self.rootViewController.view];
    [vc addChildViewController:self.rootViewController];
    [self.window setRootViewController:vc];
    
    UIView *uview = UnityGetGLView();
    [vc.view addSubview:uview];
    
    btn = [UIButton buttonWithType:UIButtonTypeSystem];
    [btn setTitle:@"To Unity" forState:UIControlStateNormal];
    [btn setBackgroundColor:[UIColor whiteColor]];
    [btn setTintColor:[UIColor orangeColor]];
    
    float Y = vc.view.frame.size.height - 80;
    float X = vc.view.frame.size.width / 2;
    
    [btn setFrame:CGRectMake(X - 200/2, Y - 50/2, 200, 50)];
    [btn addTarget:self action:@selector(tapButton:) forControlEvents:UIControlEventTouchUpInside];
    [vc.view addSubview:btn];
}

- (void)tapButton:(UIButton *)sender {
    UnitySendMessage("Button", "OnNotify", "");
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(AppController)

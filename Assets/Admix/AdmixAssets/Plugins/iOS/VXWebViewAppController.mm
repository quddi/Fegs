/**
* Copyright (c) 2021 Vuplex Inc. All rights reserved.
*
* Licensed under the Vuplex Commercial Software Library License, you may
* not use this file except in compliance with the License. You may obtain
* a copy of the License at
*
*     https://vuplex.com/commercial-library-license
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/
#import "IUnityGraphicsMetal.h"
#import "VXWebViewAppController.h"

static IUnityGraphicsMetal *_metalGraphics = nullptr;

static void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API VuplexUnityPluginLoad(IUnityInterfaces* unityInterfaces) {

    _metalGraphics = unityInterfaces->Get<IUnityGraphicsMetal>();
}

static void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API VuplexUnityPluginUnload() {}

@implementation VXWebViewAppController

- (void)shouldAttachRenderDelegate {

    // These function names are prefixed with "Vuplex" to prevent them
    // from clashing with symbols from other 3rd party plugins.
    UnityRegisterRenderingPluginV5(&VuplexUnityPluginLoad, &VuplexUnityPluginUnload);
    // Call the base class's `shouldAttachRenderDelegate` implementation in case
    // VXWebViewAppController is modified to subclass another plugin's app controller.
    [super shouldAttachRenderDelegate];
}

+ (id<MTLDevice>)metalDevice {

    if (!_metalGraphics) {
        NSLog(@"ERROR: VXWebViewAppController._metalGraphics is not set, which means another iOS graphics plugin is clashing with 3D WebView. Please see https://support.vuplex.com/articles/ios-graphics-plugin-conflict");
    }
    // If you experience an EXC_BAD_ACCESS error here, please see
    // https://support.vuplex.com/articles/ios-graphics-plugin-conflict
    return _metalGraphics->MetalDevice();
}

@end

IMPL_APP_CONTROLLER_SUBCLASS(VXWebViewAppController);

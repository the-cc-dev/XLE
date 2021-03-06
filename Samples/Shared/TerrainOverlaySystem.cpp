// Copyright 2015 XLGAMES Inc.
//
// Distributed under the MIT License (See
// accompanying file "LICENSE" or the website
// http://www.opensource.org/licenses/mit-license.php)

#include "TerrainOverlaySystem.h"
#include "../../Tools/ToolsRig/TerrainManipulatorsInterface.h"
#include "../../Tools/ToolsRig/TerrainManipulators.h"
#include "../../PlatformRig/OverlaySystem.h"
#include "../../RenderOverlays/DebuggingDisplay.h"
#include <memory>

namespace Sample
{
    using RenderOverlays::DebuggingDisplay::DebugScreensSystem;

    class TerrainManipulators
        : public PlatformRig::IOverlaySystem
        , public RenderOverlays::DebuggingDisplay::IInputListener
        , public std::enable_shared_from_this<TerrainManipulators>
    {
    public:
        TerrainManipulators(
            std::shared_ptr<SceneEngine::TerrainManager> terrainManager,
            std::shared_ptr<SceneEngine::IntersectionTestContext> intersectionContext)
        {
            _terrainManipulatorContext = std::make_shared<::ToolsRig::TerrainManipulatorContext>();
            _manipulatorsInterface = std::make_shared<::ToolsRig::ManipulatorsInterface>(terrainManager, _terrainManipulatorContext, intersectionContext);
            _terrainManipulators = std::make_shared<::ToolsRig::ManipulatorsDisplay>(_manipulatorsInterface);
            _manipInputListener = _manipulatorsInterface->CreateInputListener();

            _screens = std::make_shared<DebugScreensSystem>();
            _screens->Register(_terrainManipulators, "Terrain", DebugScreensSystem::SystemDisplay);
        }

        std::shared_ptr<RenderOverlays::DebuggingDisplay::IInputListener> GetInputListener()
        {
            return shared_from_this();
        }

        bool OnInputEvent(const RenderOverlays::DebuggingDisplay::InputSnapshot& evnt)
        {
            return  _screens->OnInputEvent(evnt)
                ||  _manipInputListener->OnInputEvent(evnt);
        }

        void RenderToScene(
            RenderCore::IThreadContext* devContext, 
            SceneEngine::LightingParserContext& parserContext)
        {
            _manipulatorsInterface->Render(*devContext, parserContext);
        }

        void RenderWidgets(
            RenderCore::IThreadContext* device, 
            const RenderCore::Techniques::ProjectionDesc& projectionDesc)
        {
            _screens->Render(device, projectionDesc);
        }

        void SetActivationState(bool) {}

    private:
        std::shared_ptr<::ToolsRig::ManipulatorsInterface> _manipulatorsInterface;
        std::shared_ptr<::ToolsRig::ManipulatorsDisplay> _terrainManipulators;
        std::shared_ptr<DebugScreensSystem> _screens;
        std::shared_ptr<RenderOverlays::DebuggingDisplay::IInputListener> _manipInputListener;
        std::shared_ptr<::ToolsRig::TerrainManipulatorContext> _terrainManipulatorContext;
    };

    std::shared_ptr<PlatformRig::IOverlaySystem> CreateTerrainEditorOverlaySystem(
        std::shared_ptr<SceneEngine::TerrainManager> terrainManager,
        std::shared_ptr<SceneEngine::IntersectionTestContext> intersectionContext)
    {
        return std::make_shared<TerrainManipulators>(
            std::move(terrainManager), 
            std::move(intersectionContext));
    }
}


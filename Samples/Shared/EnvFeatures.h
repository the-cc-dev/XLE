// Copyright 2015 XLGAMES Inc.
//
// Distributed under the MIT License (See
// accompanying file "LICENSE" or the website
// http://www.opensource.org/licenses/mit-license.php)

#pragma once

#include "IScenePlugin.h"
#include "../../Assets/AssetsCore.h"
#include <memory>

namespace SceneEngine
{
    class VolumetricFogManager;
    class VegetationSpawnManager;
    class ShallowSurfaceManager;
    class ISurfaceHeightsProvider;
}

namespace EntityInterface
{
    class EnvEntitiesManager;
    class RetainedEntities;
}

namespace Assets { class DependencyValidation; }
namespace RenderCore { namespace Assets { class ModelCache; } }

namespace Sample
{
    class ScenePlugin_EnvironmentFeatures : public IScenePlugin
    {
    public:
        void LoadingPhase();
        void PrepareFrame(
            RenderCore::IThreadContext& threadContext,
            SceneEngine::LightingParserContext& parserContext);
        void ExecuteScene(
            RenderCore::Metal::DeviceContext* context, 
            SceneEngine::LightingParserContext& parserContext, 
            const SceneEngine::SceneParseSettings& parseSettings,
            unsigned techniqueIndex) const;

        ScenePlugin_EnvironmentFeatures(
            const ::Assets::rstring& cfgDir,
            std::shared_ptr<EntityInterface::RetainedEntities> retainedEntities,
            std::shared_ptr<RenderCore::Assets::ModelCache> modelCache,
            std::shared_ptr<SceneEngine::ISurfaceHeightsProvider> surfaceHeights);
        ~ScenePlugin_EnvironmentFeatures();

    protected:
        std::shared_ptr<SceneEngine::VolumetricFogManager>      _volumetricFogMan;
        std::shared_ptr<SceneEngine::VegetationSpawnManager>    _vegetationSpawnManager;
        std::shared_ptr<SceneEngine::ShallowSurfaceManager>     _shallowSurfaces;
        std::shared_ptr<EntityInterface::EnvEntitiesManager>    _updateMan;
        std::shared_ptr<SceneEngine::ISurfaceHeightsProvider>   _surfaceHeights;

        std::shared_ptr<::Assets::DependencyValidation>     _vegetationSpawnCfgVal;
        ::Assets::rstring _cfgDir;
    };
}
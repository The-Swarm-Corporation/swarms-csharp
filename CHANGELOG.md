# Changelog

## 0.1.0 (2025-11-11)

Full Changelog: [v0.0.2...v0.1.0](https://github.com/The-Swarm-Corporation/swarms-csharp/compare/v0.0.2...v0.1.0)

### ⚠ BREAKING CHANGES

* **client:** interpret null as omitted in some properties
* **client:** make models immutable

### Features

* **api:** api update ([52d73a4](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/52d73a4fa59a4bf4b020a09cfe68fbef5413541b))
* **api:** api update ([17eddb0](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/17eddb0a68680174936864d0f6ef89b30c3b9fd0))
* **client:** add cancellation token support ([4c7e703](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/4c7e70324b0c623b32f14297c47fdf4046a66475))
* **client:** add response validation option ([44596ac](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/44596ac6b631f56748c2f86a8366b51743f54e3a))
* **client:** add retries support ([8f5a83e](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/8f5a83e3e1967c96f50fc4b3d0142e350d659561))
* **client:** add support for option modification ([7174b06](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/7174b067877e06eb1a241511c48ba95a5818bb9b))
* **client:** make models immutable ([299f48e](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/299f48ef9065a184400cc897d7769abbccce50b1))
* **client:** send `User-Agent` header ([5849b9b](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/5849b9bf641cb592478811c3dec4b6ec6c32d6ec))
* **client:** send `X-Stainless-Arch` header ([62dcec6](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/62dcec6647fc5f807e672469d5bd1d51c10efa3f))
* **client:** send `X-Stainless-Lang` and `X-Stainless-OS` headers ([4b5b148](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/4b5b1481d7d2d570b2529b1bfc2d21eb1941c2a2))
* **client:** send `X-Stainless-Package-Version` headers ([fb6c906](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/fb6c906b765ecb92bd9bb56494b0fc1a48b5626b))
* **client:** send `X-Stainless-Runtime` and `X-Stainless-Runtime-Version` ([7c865fa](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/7c865faeee138c026555cc6734b608eac9f9cb79))
* **client:** send `X-Stainless-Timeout` header ([e17e821](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/e17e821db32d69a350d18e95720e2bf71a9a7ca4))
* **client:** support request timeout ([b24a8f6](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/b24a8f68a5838804d4c3cf72eafa54e3e311753d))


### Bug Fixes

* **client:** interpret null as omitted in some properties ([9b52bdc](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/9b52bdcdcbc1f74bf4961e2449fcd0674345d2cb))
* **internal:** minor bug fixes on model instantiation and union validation ([d54282f](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/d54282fe8c57ccbe000317b63cd2e475f405ecad))


### Performance Improvements

* **client:** optimize header creation ([5a66933](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/5a6693316a4d79572773e2da5d2767c49ad92631))


### Chores

* **client:** simplify field validations ([44596ac](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/44596ac6b631f56748c2f86a8366b51743f54e3a))
* **internal:** codegen related update ([e2ae7d1](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/e2ae7d1e531d6c9c8c587b8d9b9860e239eedd7c))
* **internal:** delete empty test files ([96eead6](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/96eead62dbed97528ecb835c16b650672a4cce90))
* **internal:** extract `ClientOptions` struct ([4dfe2f9](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/4dfe2f986d018b1d81edfe79aecf6a30718a4377))
* **internal:** minor improvements to csproj and gitignore ([ca8c2c5](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/ca8c2c5497d6e37a0adfffe9737b541c3ba2ec5d))


### Documentation

* **client:** document `WithOptions` ([89bf470](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/89bf47016c836c2d222a696266c1f06ea27e2a6d))
* **client:** document max retries ([1dd3aa6](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/1dd3aa65269b60b931ed60f617f4a6f82c26a4ea))
* **client:** document timeout option ([941f3dc](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/941f3dcd7ccc872edf77962dd737495592e25cd4))
* **client:** separate comment content into paragraphs ([579c114](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/579c114223966b485a60b19845793adcf3d36347))


### Refactors

* **client:** pass around `ClientOptions` instead of client ([b041fc4](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/b041fc41a1fab715be27843fdc9e3488681c9b91))

## 0.0.2 (2025-08-07)

Full Changelog: [v0.0.1...v0.0.2](https://github.com/The-Swarm-Corporation/swarms-csharp/compare/v0.0.1...v0.0.2)

### Features

* **api:** autonomous publishing to nuget for c sharp ([4afb933](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/4afb93365571fc660dfcc7656e04082a9a11b47c))


### Chores

* configure new SDK language ([534e80a](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/534e80a0d8943795f7e9d9b4ba4038dc71a6c762))
* update SDK settings ([7baa163](https://github.com/The-Swarm-Corporation/swarms-csharp/commit/7baa163340a987a4f3a77482c21b52ef78201185))

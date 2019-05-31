/**
 * Copyright (c) Facebook, Inc. and its affiliates.
 *
 * This source code is licensed under the MIT license found in the LICENSE
 * file in the root directory of this source tree.
 */
#pragma once

#include <yoga/event/event.h>

#include <functional>
#include "yoga/YGMacros.h"

namespace facebook {
namespace yoga {
namespace test {

struct TestUtil {
  static void startCountingNodes();
  static int nodeCount();
  static int stopCountingNodes();
};

struct ScopedEventSubscription {
  ScopedEventSubscription(std::function<Event::Subscriber>&&);
  ~ScopedEventSubscription();
};

} // namespace test
} // namespace yoga
} // namespace facebook

YG_EXTERN_C_BEGIN

WIN_EXPORT void YGTestStartCountingNodes() { facebook::yoga::test::TestUtil::startCountingNodes(); };
WIN_EXPORT uint32_t YGTestGetNodeCount() { return facebook::yoga::test::TestUtil::nodeCount(); };
WIN_EXPORT void YGTestStopCountingNodes() { facebook::yoga::test::TestUtil::stopCountingNodes(); };

YG_EXTERN_C_END

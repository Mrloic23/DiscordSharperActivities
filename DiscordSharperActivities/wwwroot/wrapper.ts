import { DotNet } from "@microsoft/dotnet-js-interop";
import { DiscordSDK, EventPayloadData, Events,Types } from "@discord/embedded-app-sdk";
import { EventSchema } from "./node_modules/@discord/embedded-app-sdk/output/schema/events";

type SdkConfiguration = DiscordSDK["configuration"];

export function CreateSDKConfig(): SdkConfiguration {
    return {disableConsoleLogOverride:false};
}

export function InstantiateSDK(clientID: string, config?: SdkConfiguration| undefined){
    return new DiscordSDK(clientID, config);
}


/**
 * @param callback DotNet action to be invoked when the event is fired
 */
export async function subscribeToEvent(sdk: DiscordSDK, eventName: keyof typeof EventSchema, callback: (event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data'] | undefined) => void){
    await sdk.subscribe(eventName, callback);
}
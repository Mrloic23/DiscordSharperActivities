import { DiscordSDK, DiscordSDKMock } from "@discord/embedded-app-sdk";
import { EventSchema } from "../node_modules/@discord/embedded-app-sdk/output/schema/events.js";
import { IDiscordSDK, MaybeZodObjectArray } from "../node_modules/@discord/embedded-app-sdk/output/interface.js";

export type SdkConfiguration = DiscordSDK["configuration"];
export type EventNames = keyof typeof EventSchema;
export type EventPayloads<T extends EventNames> = Zod.infer<(typeof EventSchema)[T]['payload']>['data'];


export interface Wrapper {
    createSDKConfig: () => SdkConfiguration;
    instantiateSDK: (clientID: string, config?: SdkConfiguration | undefined) => IDiscordSDK;
    subscribeToEvent: (sdk: IDiscordSDK,
        eventName: keyof typeof EventSchema,
        callback: (event: Zod.infer<(typeof EventSchema)[keyof typeof EventSchema]['payload']>['data']) => undefined
    ) => Promise<unknown>;
    ready: (sdk: IDiscordSDK) => Promise<void>;
    getCommands: (sdk: IDiscordSDK) => DiscordSDK["commands"];
}

export interface Mock extends Wrapper {
    setGuildID: (id: string) => void;
    setChannelID: (id: string) => void;
    emitEvent: <T extends EventNames>(sdk: DiscordSDKMock, eventName: T, eventData: string) => void;
    emitReady: (sdk: DiscordSDKMock) => void;
}
declare global {
    interface Window {
        DiscordWrapper: Wrapper | Mock; 
    }
}